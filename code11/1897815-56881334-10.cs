    public static class MySceneManager
    {
        // store build index of last loaded scene
        // in order to unload it later
        private static int lastLoadedScene = -1;
    
        public static void LoadScene(int index, MonoBehaviour caller)
        {
            caller.StartCoroutine(loadNextScene(index));
        }
    
        // we need this to be a Coroutine (see link below)
        // in order to correctly set the SceneManager.SetActiveScene(newScene);
        // after the scene has finished loading. So the Coroutine is required 
        // in order to wait with it until the reight moment
        private static IEnumerator loadNextScene(int index)
        {
            // start loading the new scene async and additive
            var _async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    
            // optionally prevent the scene from being loaded instantly but e.g.
            // display a loading progress
            // (in your case not but for general purpose I added it)
            _async.allowSceneActivation = false;
            while (_async.progress < 0.9f)
            {
                // e.g. show progress of loading
                // yield in a Coroutine means
                // "pause" the execution here, render this frame
                // and continue from here in the next frame
                yield return null;
            }
    
            _async.allowSceneActivation = true;
            // loads the remaining 10% 
            // (meaning it runs all the Awake and OnEnable etc methods)
            while (!_async.isDone)
            {
                yield return null;
            }
            // at this moment the new Scene is supposed to be fully loaded
    
            // Get the new scene
            var newScene = SceneManager.GetSceneByBuildIndex(index);
    
            // would return false if something went wrong during loading the scene
            if (!newScene.IsValid()) yield break;
    
            // Set the new scene active
            // we need this later in order to place objects back into the correct scene
            // if we do not want them to be DontDestroyOnLoad anymore
            // (see explanation in SetDontDestroyOnLoad)
            SceneManager.SetActiveScene(newScene);
    
            // Unload the last loaded scene
            if (lastLoadedScene >= 0) SceneManager.UnloadSceneAsync(lastLoadedScene);
    
            // update the stored index
            lastLoadedScene = index;
        }
    }
    
