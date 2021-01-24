    public static void WriteStringToFile(string s, string fileName) 
    {
        // Let system release all the resources acquired 
        using (var file = new System.IO.StreamWriter(fileName)) 
        {
            file.Write(s);
        }  // <- here resources will be released
    }
