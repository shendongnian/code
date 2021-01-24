    using System.Collections;
    using UnityEngine.SceneManagement;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Respawn : MonoBehaviour
    {
    
        public int deaths;
        //Reference to your DeathCounter script
        public DeathCounter dCounter;
    
        private Scene scene;
    
        void Start()
        {
            scene = SceneManager.GetActiveScene();
        }
    
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.transform.CompareTag("Player"))
            {
                deaths = deaths + 1;
                //New line here, with passed in script for updating as a reference
                dCounter.SetText(deaths.ToString());
                Debug.Log("You are dead");
                System.Threading.Thread.Sleep(500);
                SceneManager.LoadScene(0);
            }
    
        }
    
    }
