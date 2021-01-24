     while ( i < clonesASpawnear.Length)
        {
            if(j <= endList)
            {
                Debug.Log("Numero j = " + j);
                //se fija que ya no este en el escenario el que va en ese punto asi no superpone items
                if (clonesASpawnear[i] == null)
                {
                    clonesASpawnear[i] = Instantiate(enemyTypeList[j], spawnPoints[j].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    clonesASpawnear[i].SetActive(true);//lo activo
                                                       //Aca le asigno el blanco que quiero que siga al spawnear
                    clonesASpawnear[i].GetComponent<EnemyMovement_DCH>().player = Target;
                    aliveEnemies += 1;
                    //aca le asigno este spawner para que pueda afectar luego las variables cuando lo maten por ejemplo
                    clonesASpawnear[i].GetComponent<EnemyDamageHandler_DCH>().SpawnerEnemies = this;
                }
                j++;
                i++;
            }
            else
            {
                j = startList;
            }
               
                
            
        
        
         Debug.Log("Numero i = " + i);
        }
    }
