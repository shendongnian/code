    public SomeLookupPair SomeLookupPair 
    { 
       get 
       { 
          (SomeLookUp.GetSomeLookup)[_someLookupID] }; 
       }
       set
       {
         _someLookupId = (SomeLookup.GetSomeLookUp).Where(s => s.Value(value)).Select(s => s.Key).SingleOrDefault;
       }
    }
