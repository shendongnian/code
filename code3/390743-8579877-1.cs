    public SomeLookupPair SomeLookupPair 
    { 
       get 
       { 
          (SomeLookUp.GetSomeLookup)[_someLookupID] }; 
       }
       set
       {
         if(value == null) throw new ArgumentNullException();
         _someLookupId = value.ID;
       }
    }
