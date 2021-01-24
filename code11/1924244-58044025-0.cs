    Could you please specify in detail what your game is about and what you are trying to do in each part of the script. I might be able to help you then. Also, if this is your first contact with programming, this is way to advanced. Start with something simpler and first understand the basic concepts of programming before moving on. Here is a good tutorial series to learn c# programming for absolute beginners. 
    
    
    
    https://www.youtube.com/watch?v=pSiIHe2uZ2w
    
    I am not sure what you are trying to do but why is your movement control within your for loop. That might be why your are messing up. Try removing all of this code out of the for loop.
    
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
                if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        
        
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeigth)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
        
                    targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        
                }
    
    Also this code should be after you check if the player has moved. 
    
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    
    
    Here is a tip to make movement a little easier. Use transform.translate instead of Vector2.MoveTowards. Transform.translate takes in 3 floats and changes you player's position by the three floats represented as a vector.
    
    Here is an example
    
        transform.translate(0,2,0);
    
    This will change the players y position by 2. I thing your code should look like this.
    
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
    
    
    
    
    
     After I receive your reply, I possibly could help but there are no guarantees because I only have about a years worth of experience too.
