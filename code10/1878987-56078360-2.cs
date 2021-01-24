    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject EnemyPreFab;
    [SerializeField] int MaxEnemies = 30;
    [SerializeField] float EnemySpawnTime = 1.00001f;
    [SerializeField] GameObject FirstWaypoint;
    int  CurrentNumOfEnemies = 0;
    public int EnemiesToNextLevel = 7;
    public int KilledEnemies = 0;
    public LevelManager myLevelManager;
    public static EnemySpawner Instance = null;
    int timesEnemyHit;
    IEnumerator SpawningEnemies()
    {
    while(CurrentNumOfEnemies <= MaxEnemies)
    {
        GameObject Enemy = Instantiate(EnemyPreFab, this.transform.position, Quaternion.identity);
        CurrentNumOfEnemies++;
        yield return new WaitForSeconds(EnemySpawnTime);
    }
    }
    void Start()
    {
    if (Instance == null)
        Instance = this;
    StartCoroutine(SpawningEnemies());
    timesEnemyHit = 0;
    if (this.gameObject.tag == "EnemyHit")
    {
        CurrentNumOfEnemies++;
    }
    }
    public void OnEnemyDeath()
    {
      CurrentNumOfEnemies--;
    /*     
    if (CurrentNumOfEnemies < 5)
     {
         // You killed everyone, change scene: 
         LaserLevelManager.LoadLevel("NextLevelMenu");
     }
     */
    KilledEnemies++;
     
    if (Time.timer > 0 && KilledEnemies >= EnemiesToNextLevel)
    {
        LaserLevelManager.LoadLevel("NextLevelMenu");
    }   
    }
    }
