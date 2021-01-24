public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "playerdata.bcdata";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            String message = "Save file 'playerdata.bcdata' was not found, please reinstall the missing file (error in: " + path + ")";
            Debug.LogError( message  );
            throw new InvalidOperationException( message );
        }
    }
