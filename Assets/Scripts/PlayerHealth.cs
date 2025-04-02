using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLive = 3;
    public int currentLives;

    public float invincibleTime = 1.0f;
    public bool isInvincible = false;


    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            currentLives--;
            Destroy(other.gameObject);

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }


    void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame" , 3.0f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

