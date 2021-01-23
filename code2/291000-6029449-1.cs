    public string[,] GetRecordFields(string selectedRecord)
    {
        //List<Tuple<string, Dictionary<string, string>>> _recordMasterList;
        
        List<Dictionary<string, string>> selectedRecords
            = (from record in _recordMasterList
                where record.Item1 == selectedRecord
                select record.Item2)
                .ToList();
        int totalNumberOfRecords = 0;
        
        foreach(Dictionary<string, string> d in selectedRecords)
        {
            totalNumberOfRecords += d.Count();
        }
            
        string[,] result = new string[2, totalNumberOfRecords];
        
        int i = 0;
        foreach(Dictionary<string, string> d in selectedRecords)
        {
            foreach(KeyValuePair<string, string> kvp in d)
            {
                result[0,i] = kvp.Key;
                result[1,i] = kvp.Value;
                ii++;
            }
        }
        
        return result;
    }
