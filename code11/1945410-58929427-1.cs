    public GameData gameData;
    private void LoadGameData()
    {
        string path = "ItemsData";
        TextAsset targetFile = Resources.Load<TextAsset>(path);
        string json = targetFile.text;
        gameData = JsonUtility.FromJson<GameData>(json);
        print(gameData.Items.Count);
    }
