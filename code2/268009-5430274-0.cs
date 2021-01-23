    [Serializable]
    public class GameData
    {
        public int Highscore;
        /* Plus any other data you want to store */
    }
    public class Game
    {
        private const string gameDataLocation = "C:\\GameData.xml";
        private GameData gameData;
        /* Your game methods */
        private void StoreData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            StreamWriter writer = new StreamWriter(gameDataLocation);
            serializer.Serialize(writer, gameData);
            writer.Close();
        }
        private void LoadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            FileStream fileStream = new FileStream(gameDataLocation, FileMode.Open); 
            gameData = (GameData)serializer.Deserialize(fileStream);
            fileStream.Close();
        }
    }
