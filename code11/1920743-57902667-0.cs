    public static List<Settlement> ReadFromLogFile()
    {
        string filename = path + @"\BM_DB_MIGRATION.txt";
        List<Settlement> settlements = new List<Settlement>();
    
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
    
            // Reading 7 elements from lines into an object of Settelment at each iteration 
            // and store the object in a list of objects...
            settlements.AddRange(lines.Select(l => new Settlement(l.SubString(0,6))));
        }
    
        return settlements;
    }
