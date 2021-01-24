    public static List<Settlement> ReadFromLogFile()
    {
        string filename = path + @"\BM_DB_MIGRATION.txt";
        List<Settlement> settlements = new List<Settlement>();
    
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
    
            // Reading 7 elements from lines into an object of Settelment at each iteration 
            // and store the object in a list of objects...
            var record = new List<string>(7);
            foreach (var line in lines)
            {
                if (record.Count == 7)
                {
                    // convert the lines to the Settlement data structure
                    var s = new Settlement(record);
                    settlements.Add(s);
                    record.Clear();
                }
    
                record.Add(line);
            }
        }
    
        return settlements;
    }
