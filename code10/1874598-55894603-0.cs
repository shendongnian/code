    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class LoadScenes : MonoBehaviour {
    
    public LevelManager lvlManager;
    
    //If the ball hits one of the walls the colliders will be triggered
    void OnTriggerEnter2D()
    {
        print("The wall is triggered by the ball");
        lvlManager.LoadLevel("Lose"); // <-- This here is your problem
        Bricks.brickCount = 0;
    
        if(Health.health == 0)
        {
           lvlManager.LoadLevel("Lose");
        }
    }
    
    
    
    void OnCollisionEnter2D()
    {
        Debug.Log("The ball has collided with the wall");
     }
    
    }
