       public class TestModel
       {
          public TestModel()
          {
             Dictionary<int, int> RowDict = new Dictionary<int, int>(); 
             for (int i = 1; i < 11; i++) 
             { 
                RowDict.Add(i, i); 
             }
    
             this.Rows = new SelectList(RowDict, "Key", "Value");
             this.SelectedId = "6"; // binding to selection works as a String
          }
    
          public SelectList Rows { get; set; }
          public string SelectedId { get; set; }
    
       }
