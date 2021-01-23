    int pairIndex = 0;
    for(i = 0; i<5; i++)
    {
        for (; pairIndex < dictionary.Count; pairIndex++)
        {
              KeyValuePair<string, string> pair = dictionary.ElementAt(pairIndex);
              /* do something */
              if(consdition) break;
         }
     }
