    public static void SetMusicOnOFF(int value)
    {
        PlayerPrefs.SetInt(Music, value);
        PlayerPrefs.Save();
    }
