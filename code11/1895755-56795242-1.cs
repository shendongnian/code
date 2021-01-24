    private YourFirstScript yourFirstScript;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            // Add the callback
            // it is save to remove even if not added yet
            // this makes sure a callback is allways added only once
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
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
        yourFirstScript.Start();
    }
