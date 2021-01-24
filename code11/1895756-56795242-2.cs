    private YourFirstScript yourFirstScript;
    // rather implement a Singleton pattern this way
    private static GameSession Instance;
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        // Add the callback
        // it is save to remove even if not added yet
        // this makes sure a callback is allways added only once
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        yourFirstScript = GetComponentInChildren<YourFirstScript>(true);
    }
    private void OnDestroy()
    {
        // make sure to remove callbacks when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // called everytime a scene was loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Since you made it public anyway simply call the method
        // of your first script
        // You shouldn't call it Start anymore
        // because now it will be called twice
        yourFirstScript.Start();
    }
