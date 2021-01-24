    public static class DataService
    {
        public static GameData GameData = new GameData();
        public static void SaveGameData1()
        {
            var json = JsonUtility.ToJson(_gameData);
            var filePath = Path.Combine(Application.persistentDataPath, "GameData1.json");
            if (File.Exists(filePath))
            {
                File.Create(filePath);
            }
            File.WriteAllText(filePath,json);
        }
        public static void LoadGameData()
        {
            var filePath = Path.Combine(Application.persistentDataPath, "GameData1.json");
            
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(_filePath);
                JsonUtility.FromJsonOverwrite(json, GameData);
            }
            else
            {
                Debug.Log("File missing.");
            }
        }
    }
