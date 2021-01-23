    void SaveTuples(List<tuple> tuples)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (StreamReader sr = new StreamReader(ms))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, tuples);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.tuples = Convert.ToBase64String(buffer);
            }
        }
    }
    List<tuple> LoadTuples()
    {
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.tuples)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (List<tuple>)bf.Deserialize(ms);
        }
    }
	
