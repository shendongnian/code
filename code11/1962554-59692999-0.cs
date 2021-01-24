    public class SaveSystem
    {
        static string path = Application.persistentDataPath + "/user.frostbyte";
        
        public static void SaveUser()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, new UserData());
            stream.Close();
        }
        public static UserData LoadData()
        {
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                UserData data = formatter.Deserialize(stream) as UserData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
