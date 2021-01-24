    public static class SaveSystem
    {
        public static PlayerData Data;
   
        // Without a parameter serialize the values from the current Data
        // which will be updated by the player
        public static void SavePlayer()
        {
            WriteFile(Data);
        }
 
        public static void SavePlayer(Player player)
        {
            var data = new PlayerData(player);
            WriteFile(data);
        }
        private static void WriteFile(PlayerData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.bin";
            FileStream stream = new FileStream(path, FileMode.Create);
    
            formatter.Serialize(stream, data);
            stream.Close();
        }
    
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.bin";
            if(File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
    
                Data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
    
                return Data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
