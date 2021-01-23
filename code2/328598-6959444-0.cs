       public class TestModel
       {
          public TestModel()
          {
             Dictionary<int, int> RowDict = new Dictionary<int, int>(); 
             for (int i = 1; i < 11; i++) 
             { 
                RowDict.Add(i, i); 
             }
    
             this.Rows = new SelectList(RowDict, "Key", "Value", 6);
          }
    
          public SelectList Rows { get; set; }
    
       }
