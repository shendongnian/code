    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused) {
            // ..
            PlayerPrefs.Save();
        }    
    }
