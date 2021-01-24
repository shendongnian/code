    //when the player's box collider collides with another box collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //scene moves to a game over screen
            SceneManager.LoadScene("Player Death");
            //Reset score everytime player dies
            resetScore();
        }
    }
    // Start is called before the first frame update
    void Start()
    { }
    
    // Update is called once per frame
    void Update()
    {
    
    }
    
    void resetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
