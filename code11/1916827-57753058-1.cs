    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("player") || !string.Equals(counter.text, "X 3")) return;
        
        Invoke("SwitchScene", 4f);  
    }
    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
