public class EnemySpawner : MonoBehaviour 
{
    public static Spawner Instance = null;
    int CurrentNumOfEnemies = 0;
    // ... etc
    
    void Start() 
    {
        if (Instance == null)
             Instance = this;
        // Spawn enemies like you do already, CurrentNumOfEnemies++ for every spawned
    }
    public OnEnemyDeath() {
        CurrentNumOfEnemies--;
        if (CurrentNumOfEnemies < 1) 
        {
            // You killed everyone, change scene: 
            LevelManager.LoadLevel("Your Level");
        }
    }
}
Enemy script (I don't know how your current code looks, but here's a minimal solution based on how I **THINK** your code looks):
void OnDestroy() 
{
    // This will run automatically when you run Destroy() on this gameObject
    EnemySpawner.Instance.OnEnemyDeath(); // Tell the EnemySpawner that someone died
}
This will only work if you have exactly only ONE spawner. If you have multiple ones you will have to send a reference to the instance of its spawner to every spawned enemy. I can show you how to do ths too, if you wish.
----
### Bonus content
LevelManager doesn't need to be on a GameObject, it can be static instead:
1. Remove the LevelManager script from any GameObject
1. Change your LevelManager code to this:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class LevelManager 
{
    public static void LoadLevel(string name)
    {
        Debug.Log("Level loading requested for" + name);
        SceneManager.LoadScene(name);
    }
}
Now you can use it from ANYWHERE, without needing to initialize a reference to any script or GameObject:
LevelManager.LoadLevel("My Level");
