     void LodeGame()
    {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Open (Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Game save = (Game)bf.Deserialize (file);
        file.Close ();
        this.Cuens = save.Cuens; // restore value.
        Debug.Log (save);
    }
