    // Returns true if the data exists; False if the data did not.
    public bool TryLoad(out AllData allData) {
        allData = null;
        if (File.Exists(Application.persistentDataPath + "/allData.hey")) {
    
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/allData.hey", FileMode.Open);
            allData = (AllData)bf.Deserialize(file);
            file.Close();
        }
        return allData != null;
    }
