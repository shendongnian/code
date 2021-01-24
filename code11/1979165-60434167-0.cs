    if (Input.GetKeyDown(KeyCode.P))
    {
        // This can be cleaner, just for logic to not load current scene
        int randomScene = UnityEngine.Random.Range(0, 6);
        while (_sceneCounter == randomScene)
        {
            randomScene = UnityEngine.Random.Range(0, 6);
        }
        _sceneCounter = randomScene;            
        SceneManager.LoadSceneAsync(_sceneCounter.ToString(), LoadSceneMode.Additive);
        _lastScene = SceneManager.GetSceneByName(_sceneCounter.ToString());
        SceneUnloader();
    }
