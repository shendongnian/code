    public void ProcessLists()
        {
           const int keysNumber = 2;
           var totalLength = R1[0].Count + R2[0].Count - keysNumber;
           // add first list to dictionary
           JoinList(R1, keysNumber);
           var paddingAfterKeys = R1[0].Count - keysNumber;
           // add the second list to dictionary and add padding if a key was not found in dictionary
           JoinList(R2, keysNumber, paddingAfterKeys);
           
           // add padding to the end if a key was found in first list but not in second
           paddingAfterKeys = R2[0].Count - keysNumber;
           
           var paddingList = new List<string>();
           for (var i = 0; i < paddingAfterKeys; i++)
           {
               paddingList.Add("0");
           }
           foreach (var keyValuePair in result.Where(x => x.Value.Count < totalLength))
           {
              keyValuePair.Value.AddRange(paddingList);
           }
        }
