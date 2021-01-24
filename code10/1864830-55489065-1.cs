    using UnityEngine.SceneManagement;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DifficultyManagement.setDifficulty(Difficulty.One); // start the game with diff one always
            DontDestroyOnLoad(this.gameObject);
    	    SceneManager.sceneLoaded += (scene, mode) => StartCoroutine(InitMaxScore());
        }
    }
