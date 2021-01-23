    for( int i =0 ; i < lines.length -1 ;i++)
    {
             if (!string.IsNullOrEmpty(lines[i]) && lines[i].StartsWith("#MatchOne") || lines[i].StartsWith("#MatchTwo"))
             {
                 string test = lines[i];
                 if ( !dictionary.ContainsKey(test))
                 {
                     dictionary.Add(test, lines[i+1]);
                 }
                 else
                 {
                     throw new Exception("File not in expected format.");
                 }
             }
    }
