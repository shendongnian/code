    List<string> collection = new List<string>();
    
    foreach( var line in File.ReadLines("file.txt") )
    {
         if( line.StartsWith("master"))
         {
            if( collection.Count > 0 )
            {
                 WriteRecords(collection);
            }
            collection.Clear();
         }
         collection.Add(line);
    }
         
