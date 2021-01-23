    public bool GetData(string filename, out string data)
    {
        if (File.Exists(filename))
        {
            data = File.ReadAllText(filename);
            return true;
        }
        data = string.Empty;
        return false;
    }
    string data;
    if (GetData(Server.MapPath("/myFile.txt"), out data))
    {
         // do something with data
    }
