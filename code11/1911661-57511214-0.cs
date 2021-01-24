    void Awake()
    {
        Load();
    }
    void OnApplicationQuit()
    {
        Save();
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus) Load();
        else Save();
    }
    void Load()
    {
        long nowTicks = DateTime.UtcNow.Ticks;
        long prevTicks = nowTicks;
        string prevTicksString = PlayerPrefs.GetString("ticks", string.Empty);
        if (!string.IsNullOrEmpty(prevTicksString)) prevTicks = long.Parse(prevTicksString);
        double secondsPassed = TimeSpan.FromTicks(nowTicks - prevTicks).TotalSeconds;
        Debug.Log(secondsPassed);
    }
    void Save()
    {
        PlayerPrefs.SetString("ticks", DateTime.UtcNow.Ticks.ToString());
        PlayerPrefs.Save();
    }
