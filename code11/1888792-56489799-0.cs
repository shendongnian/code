     public static IEnumerable<SourceModel> GetRecord(string ID)
     {
         var recs = Source.GetRecords(ID);
         return  recs; // no error now as you are returning list
     }
