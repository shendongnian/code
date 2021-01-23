    void SerializeVector3Array(string filename, Vector3[,] array)
    {
        BinaryFormatter bf = new BinaryFormatter();
        Stream s = File.Open(filename, FileMode.Create);
        bf.Serialize(s, array);
        s.Close();
    }
    Vector3[,] DeserializeVector3Array(string filename)
    {
        Stream s = File.Open(filename, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        Vector3[,] array = (Vector3[,])bf.Deserialize(s);
        s.Close();
        return array;
    }
