    // initial " list of non-negative integer values"
    // I've declared it as long, since 100044022000301 > int.MaxValue 
    List<long> list = new List<long>() {
      4555223,
      123,
      456,
      100044022000301L,  // we want this value (just before the sentinel)
     -1L,                // sentinel
      789,
    };
    long result = long.Parse(Regex.Replace(list
      .TakeWhile(item => item != -1) // up to sentinel
      .Last()                        // last value up to sentinel
      .ToString(),
       "0{2,}",                      // change two or more consequent 0 
       "0"));                        // into 0
