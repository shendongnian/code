     while (ee.MoveNext())
     {
         if (ee.Current.StartsWith("#MatchOne") || ee.Current.StartsWith("#MatchTwo"))
         {
             string test = ee.Current;
             if (ee.MoveNext() && !dictionary.ContainsKey(test))
             {
                 dictionary.Add(test, ee.Current);
             }
             else
             {
                 throw new Exception("File not in expected format.");
             }
         }
     }
