    public void CallLoadNextScene()
    {
        Invoke("LoadNextScene",yourDelay);
    }
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void CallLoadMenu(int id)
    {
        Invoke("LoadMenuScene",yourDelay);
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
