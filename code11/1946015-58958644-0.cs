using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomizedSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject prefab3;
    [SerializeField] private GameObject prefab4;
    [SerializeField] private GameObject prefab5;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private int maxSpawnCount = 3;
    private float _timer;
    private int _random;
    private int _spawnCount;
    private void Update()
    {
        if (_spawnCount < maxSpawnCount)
        {
            _timer += Time.deltaTime;
            if (_timer >= spawnRate)
            {
                _timer -= spawnRate;
                SpawnRandomPrefab();
            }
        }
        else
        {
            YourOtherFunction();
        }
        
    }
    private void SpawnRandomPrefab()
    {
        _random = Random.Range(1, 6);
        Debug.Log(_random);
        switch (_random)
        {
            case 1:
                Instantiate(prefab1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(prefab2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(prefab3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(prefab4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(prefab5, transform.position, Quaternion.identity);
                break;
        }
        _spawnCount++;
    }
    private void YourOtherFunction()
    {
        
    }
}
