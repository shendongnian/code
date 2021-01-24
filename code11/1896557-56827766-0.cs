    void Update()
    {
        if (Input.GetKeyDown("j") && colide)
        {
            SceneManager.LoadScene(Cena3);
            Debug.Log("he's in the last scene");
        }
    }
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        colide = true;
        Debug.Log("inside");
    }
    
    void OnTriggerExit2D(Collider2D colisor)
    {
        colide = false;
        Debug.Log("Outside");
    }
