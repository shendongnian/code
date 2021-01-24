    public class GameControl : MonoBehaviour
    {
      public float health;
      public float experience;
      
      public void Save()
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        
        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;
        
        bf.Serialize(file, data);
        file.Close();
      }
      
      public void Load()
      {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
          BinaryFormatter bf = new BinaryFormatter();
          FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
          PlayerData data = (PlayerData)bf.Deserialize(file);
          file.Close();
          
          health = data.health;
          experience = data.experience;
        }
      }
    }
    [Serializable]
    class PlayerData
    {
      public float health;
      public float experience;
    }
