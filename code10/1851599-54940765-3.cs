        }
    
        void Update ()
        {
    
        }
    
        void IEnumerator CreateEnemy()
        {
            Instantiate (enemyPrefeb, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(generatorTimer);
            generatorTimer = Random.Range(1f, 5f);
        }
    
        public void StartGenerator()
        {
            StartCoroutine(CreateEnemy());
    
        }
    
        public void CancelGenerator(bool clean = false)
        {
            CancelInvoke ("CreateEnemy");
            if (clean)
            {
                Object[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
                foreach (GameObject enemy in allEnemies)
                {
                    Destroy(enemy);
                }
            }   
        }
    }
