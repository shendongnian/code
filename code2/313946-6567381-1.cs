       // Optional seperators 
       public IEnumerable<int> ParseInts(string integers, params char[] separators)
       {
           foreach (var intString in integers.Split(separators))
           {
                yield return int.Parse(intString);
           }
       }
       public IEnumerable<int> ParseInts(string integers)
       {
            return ParseInts(integers, ' ');
       }
