    public void Save()
    {
        // HERE YOU OVERWRITE coins
        coins = Coins.value;
        Debug.Log("Saving");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/coins.dat");
        PlayerData data = new PlayerData();
        // YOU CREATE A NEW DATA OBJECT AND ASSIGN coins WHICH BASICALLY NOW EQUALS Coins.Value
        data.coins = coins;
        bf.Serialize(file, data);
        file.Close();
    }
