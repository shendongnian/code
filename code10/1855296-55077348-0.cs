    [SerializeField]
    public Text scoreText;
    //float startTime;
    public const string scorePrefix = "Timer: ";
    //Timer initializer
    float  elapsedSeconds=0;
    //Stop Timer initializer
    bool gameTimerIsRunning;
    // Start is called before the first frame update
    void Start()
    {
       
        gameTimerIsRunning = true;
        
        scoreText.text = scorePrefix + "0";
    }
    // Update is called once per frame
    void Update()
    {
        if (gameTimerIsRunning)
        {
            elapsedSeconds += Time.deltaTime;
            int timer = (int)elapsedSeconds;
            scoreText.text = scorePrefix + timer.ToString();
            Debug.Log("YOO....");
        }
        else
        {  }
       
    }
    public void StopGameTimer()
    {
          gameTimerIsRunning = false;
            elapsedSeconds = 0;
        Debug.Log("Timer Stops.");
     }
