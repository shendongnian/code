    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Bricks : MonoBehaviour {
        public LevelManager myLevelManager;        
        public int maxNumberOfHits = 0;
        int timesHit;
        public AudioClip BlockBreaking;
    
        // Use this for initialization
        void Start () {
            timesHit = 0;
            myLevelManager.AddBrick();
            // I'm not sure why you were checking the tag here, since the result was the same  
        }
    
        void OnCollisionEnter2D()
        {
            timesHit++;
    
            if (timesHit == maxNumberOfHits)
            {
                myLevelManager.RemoveBrick();
                Destroy(this.gameObject); 
            }
            /* This looks like the player is getting score whether the brick is destroyed or not. Also, it would appear the player won't get scored on the final brick */
            if(this.gameObject.tag == "BrickHit") //If the gameObject (Block One Point) with the tag "BrickHit" is hit
            {
                Scores.scoreValue += 1;//The user will be rewarded 1 point
                AudioSource.PlayClipAtPoint(BlockBreaking, transform.position);
            }
    
            if(this.gameObject.tag == "BrickHitTwice") //If the gameObject (Block Two Points) with the tag "BrickHitTwice" is hit
            {
                Scores.scoreValue += 2; //The user will be rewarded 2 points
                AudioSource.PlayClipAtPoint(BlockBreaking, transform.position);
            }   
        }
    }
