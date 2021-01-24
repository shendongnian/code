    void Update() {
        if (aliveEnemies < maxAmmoutOfEnemiesOnStage && j <= endList)
        {      
                if (clonesASpawnear[i] == null)
                {
                    if (sPCurrent == sPMax)
                    {
                        sPCurrent = 0;
                    }                   
                clonesASpawnear[i] = Instantiate(enemyTypeList[j], spawnPoints[sPCurrent].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    clonesASpawnear[i].SetActive(true);
                    clonesASpawnear[i].GetComponent<EnemyMovement_DCH>().player = Target;
                    aliveEnemies += 1;
                    clonesASpawnear[i].GetComponent<EnemyDamageHandler_DCH>().SpawnerEnemies = this;
                    j++;
                    i++;
                    sPCurrent++;
                }
            }               
        else
        {
            j = startList;
        }   
    }
