    public static void WriteStringToFile(string s, string fileName)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
        file.Write(s);                            
        DiscardFile(file);
        //Is this redundant?                                        Yes, it's redundant
        //Or is the line in the called function the redundant line?
        file = null;
    }
