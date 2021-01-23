    void SaveTuples(List<tuple> tuples)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, tuples);
            ms.Position = 0;
            byte[] buffer = new byte[(int)ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            Properties.Settings.Default.tuples = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
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
	
