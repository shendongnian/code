    [SerializeField] TextMeshProUGUI livesText;
    // Note that [SerializeField] makes no sense for static fields
    private static int currentLives = 4;
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
            SceneManager.sceneLoaded -= OnSceneLoaded
            SceneManager.sceneLoaded += OnSceneLoaded;;
        }
    }
    private void OnDestroy()
    {
        // make sure to remove callbacks when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // called everytime a scene was loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        livesText.text = "Lives: " + currentLives.ToString();
        Debug.Log(currentLives);
    }
    public void Start()
    {
        livesText.text = "Lives: " + currentLives.ToString();
        Debug.Log(currentLives);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentLives > 0)
        {
            currentLives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (currentLives <= 0)
        {
            SceneManager.LoadScene("Game Over");
            currentLives = 4;
        }
    }
    
