    public int value = 0;
    void Awake()
    {
        //Load your previously saved score (this value will be saved even if you restart the app)
        value = PlayerPrefs.GetInt("Score");
    }
    public void button1(int sc)
    {
        //Save your value before you load the scene
        PlayerPrefs.SetInt("Score", value);
        SceneManager.LoadScene(sc);
    }    
