I have a much longer and more advanced routine in my core code, but essentially you want to parse the first line into headers and then subsequent lines get read into a Dictionary containing the information you want.
    const string MYCSV = @"....";
    IEnumerable<IDictionary<string, string>> ReadFile()
    {
        IDictionary<int, string> headers = new Dictionary<int, string>();
        foreach (string line in System.IO.File.ReadLines(MYCSV))
        {
             if (headers.Count == 0)
             {
                 headers.AddRange(
                    line.Split(',')
                        .Select((nm, i) => new KeyValuePair<int, string>(i, nm));
                 );
                 continue;
             }
             IDictionary<string, string> record = new Dictionary<string, string>();
             record.AddRange(
               line.Split(',')
                   .Select((val, i) => new KeyValuePair<string, string>(headers[i], val);
             );
             yield return record;
        }
    }
    void GatherData()
    {
         foreach (IDictionary<string, string> record in ReadFile())
         {
               int readingNumber = record["Index"].Parseint();
               ....
         }
    }
    
