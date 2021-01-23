    public static DDocument Load(string path)
    {
        using(FileStream fs = new FileStream(path, FileMode.Open)) {
            return DDocument.Load(fs); 
        }
    }
