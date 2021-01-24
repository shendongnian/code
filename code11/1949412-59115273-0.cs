    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Main");
            Debug.Log("Scene Restarted");
        }
    }
