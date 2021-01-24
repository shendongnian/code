    void OnEnable()
    {   
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
         
    void OnDisable()
    {  
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
         
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(StartPoolingNextLevel(yourObjectPooler));
    }
    
    private IEnumerator StartPoolingNextLevel(YourObjectPoolerClass yourObjectPooler)
    {
        for (int i = 0; i < yourObjectPooler.AmountToPool; i++)
        {
            yourObjectPooler.PoolItem(); // psuedo code
            yield return new WaitForEndOfFrame();
        }
    }
