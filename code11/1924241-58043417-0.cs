    using UnityEngine;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System;
    
    public static class SaveSystem
    {
    
       
    
        public static void SaveData(PlayerCollision playerCol)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
    
            GameData data = new GameData(playerCol);
    
            formatter.Serialize(stream, data);
            stream.Close();
        }
    
        public static GameData LoadData(PlayerCollision playerCol)
        {
            string path = Application.persistentDataPath + "/player.fun";
            FileStream stream = new FileStream(path, FileMode.Open);
            if (File.Exists(path) && stream.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                GameData data = formatter.Deserialize(stream) as GameData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save file was not found in " + path);
                BinaryFormatter formatter = new BinaryFormatter();
                GameData data = new GameData(playerCol);
                formatter.Serialize(stream, data);
                stream.Close();
                return data;
            }
        }
    
    }
    
    
    
