    void Start () {
        gameOver = false;
        StartCoroutine (SpawnWaves());
    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (gameOver != true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if(gameOver)break;
                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Instantiate(enemy, spawnPosition1, spawnRotation1);
                Instantiate(enemy, spawnPosition2, spawnRotation2);
                Instantiate(enemy, spawnPosition3, spawnRotation3);
                Instantiate(enemy, spawnPosition4, spawnRotation4);
                Instantiate(enemy, spawnPosition5, spawnRotation5);
                Instantiate(enemy, spawnPosition6, spawnRotation6);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            enemies[0].GetComponent<EnemyBehviour>().currentHealth *= eenter code herenemyHealthMultiplier;
        }
    }
