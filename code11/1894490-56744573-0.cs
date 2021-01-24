    public void CallLoadNextScene()
    {
        invoke("LoadNextScene",yourDelay);
    }
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void CallLoadMenu(int id)
    {
        invoke("LoadMenuScene",yourDelay);
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
