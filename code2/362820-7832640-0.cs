    Dictionary<string, int> counts = new Dictionary<string, int>();
    foreach(string s in list) 
    {
       int prevCount;
       if (!counts.TryGet(s, out prevCount))
       {
          prevCount.Add(s, 1);
       }
       else
       {   
           counts[s] = prevCount++;
       }
    }
