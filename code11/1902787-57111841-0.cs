     void LodeGame()
    {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Open (Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Game save = (Game)bf.Deserialize (file);
        // you never do something with this
        file.Close ();
        Debug.Log (save);
    }
