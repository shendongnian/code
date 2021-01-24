    public void NextString()
    {
        start = true;
        сharIndex = 0;
        time = 0f;
        if (index_of_string + 1 < MultiStrings.Length)
        {            
            index_of_string++;
        }
        else if (index_of_string + 1 == MultiStrings.Length)
        {
            Debug.LogWarning("Console Loading...");
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
        ORIGINAL_TEXT = MultiStrings[index_of_string];
    }
