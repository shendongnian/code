    //Load random level scene
            int index = Random.Range(2, 4);
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    
    Suppose if here 'index' number is 3 and scene 3 is loaded.ok no problem.
    
    //Unload current scene and load new random level scene
    
            int index = Random.Range(2, 4);
            SceneManager.UnloadSceneAsync(index);
    
    And here 'index' number is generate again such as 2.You want to unlode scene 2 but is not there thats the problem.
    
    Solution :-
    
    //Load random level scene
            int index = Random.Range(2, 4);
            int lodedScene = index;
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            Debug.Log("SceneLoaded");
    
    
    //Unload current scene and load new random level scene
    
            int index = Random.Range(2, 4);
            SceneManager.UnloadSceneAsync(lodedScene);
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            Debug.Log("SceneLoaded");
