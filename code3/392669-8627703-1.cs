    while (reader.Read()){
        //now you can get any values by column index like
        int i = reader.GetInt32(0);
        string s = reader.GetString(1);
        double d = reader.GetInt32(2);
        DateTime dt = reader.GetDateTime(3);
    }
