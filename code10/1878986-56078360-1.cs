    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class Timer : MonoBehaviour
     {
    public Text TimerText;
    public float MainTime;
    public static float timer;
    public  bool CanCount = true;
    public  bool OnlyOnce = false;
    void Start()
    {
    timer = MainTime; //Timer is gonna be equal to what we set MainTime in the     inspector 
    }
    void Update()
    {
    if (timer >= 0.0f && CanCount)
    {
        timer -= Time.deltaTime;//The timer will count down in delta time based on the seconds we have 
        TimerText.text = timer.ToString("F");//Converting Timer into a string value 
    }
    //This means that when the timer reaches zero and OnlyOnce is equal to false 
    else if (timer <= 0.0f && !OnlyOnce) //If the timer goes below 0 and OnlyOnce is not equal to flase 
    {
        CanCount = false; //CanCount is equal to false so we are not counting down anymore since it's not greater than zero and we can't count anymore
        OnlyOnce = true; //This is goning to be done once when it reaches it 
        TimerText.text = "0.00"; //Setting the UI to 0 
        timer = 0.0f; //Setting the timer to 0
        if(Time.timer == 0.0f && EnemySpawner.Instance.KilledEnemies != EnemySpawner.Instance.EnemiesToNextLevel)
        {
        LaserLevelManager.LoadLevel("Lose");
        }
            }
        }
    }
