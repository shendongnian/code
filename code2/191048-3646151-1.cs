    CrossTabDataObject
    {
       string RowName{get;set;};
       int RowId{get;set;}
       List<string> CellContents{get;set;}
       //Constructor
       public CrossTabDataObject()
       {
         CellContents = new List<string>();
       }
    }
