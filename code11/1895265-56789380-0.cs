    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
           DateTime time = DateTime.Now;
           SaveVariablesInClass();
           PlayerPrefs.SetString("SV", JsonUtility.ToJson(save)); //saves special class
        }
    }
