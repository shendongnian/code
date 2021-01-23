    class MyCache
    {
      public static Dictionary<string,string> Cache = new Dictionary<string,string>();
      public static void FillCache()
      {
        GetAllRecord getAllStates = new GetAllRecord();
        getAllStates.recordType = GetAllRecordType.state;
        getAllStates.recordTypeSpecified = true;
        GetAllResult stateResult = _service.getAll(getAllStates);
        Record[] stateRecords = stateResult.recordList; 
        if (stateResult.status.isSuccess)
        {
            foreach (State state in stateRecords)
            {
                Cache[state.fullName.ToUpper()] = state.shortname;
            }
        }
        // and some code to do the rest of the web service calls until you have all results.
     }
    }
    void Main()
    {
       // initialize the cache
       MyCache.FillCache();
    }
