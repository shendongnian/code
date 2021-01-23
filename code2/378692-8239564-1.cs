    struct ValueParts
    {    
         public readonly SearchCriteria criteria;
         public readonly SearchType type;
         public readonly string prefix; 
         public ValueParts(SearchCriteria c, SearchType t, string p) 
         {
             criteria = c;
             type = t;
             prefix = p;
         }
    }
