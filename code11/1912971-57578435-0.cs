    public void button1(int sc)
    {
        PlayerPrefs.SetInt("Score", value);
        SceneManager.LoadScene(sc);
    }
    void Awake()
    {
        value = PlayerPrefs.GetInt("Score");
    }
    
