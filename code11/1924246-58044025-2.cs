    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
        
    public class Player : MonoBehaviour
    {
        private Vector2 targetPos;
        public float Yincrement;
        
        public float speed;
        public float maxHeight;
        public float minHeigth;
        
        public int health = 3;
        public int numOfHearts;
        
        public Image[] hearts;
        public Sprite heartFull;
        public Sprite heartEmpty;
        
        public GameObject effect;
        
        public Image healthDisplay;
        
        private void Update()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = heartFull;
                }
                else
                {
                    hearts[i].sprite = heartEmpty;
        
                    if (i < numOfHearts)
                    {
                        hearts[i].enabled = true;
                    }
                    else
                    {
                        hearts[i].enabled = false;
                    }
                }
            }
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            {
                transform.Translate(0,Yincrement,0)
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeigth)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
        
                transform.Translate(0,Yincrement,0);
            }
        }
    }
    
    
