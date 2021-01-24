    void Update()
    {
    
     if (showerStart == true) {            
            showerStart = false; //to ensure that your coroutine called once
            StartCoroutine(SmallShower());
        }
    }
    
    IEnumerator SmallShower()
    {
        while (smallWaveCount > 0)
        {
            yield return new WaitForSeconds(smallWaveTimer);// smallWaveTimer = 2.33f
            smallPickerNum1 = Random.Range(0, smallCounter - 1); // Needs to randomize each run
            smallPickerNum2 = Random.Range(0, smallCounter - 1);
            while (smallPickerNum2 == smallPickerNum1)
            {
                smallPickerNum2 = Random.Range(0, smallCounter - 1);
            }
            getSpawnZone1 = meteorSpawnSmall[smallPickerNum1];//Grabs the spawnzone from list
            getSpawnZone2 = meteorSpawnSmall[smallPickerNum2];//Grabs the 2nd spawn zone from list
            Instantiate(smallMeteor, getSpawnZone1.transform.position, Quaternion.identity);
            Instantiate(smallMeteor, getSpawnZone2.transform.position, Quaternion.identity);
            smallWaveCount--;//smallWaveCount starts at int 10
        }
    }
