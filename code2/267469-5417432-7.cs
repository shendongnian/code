        public class TestItem : ITestItem
        {
          public TestItem() 
          { 
             this.Properties = new Meta();//set it from here
             this.Items = new List<int>();
          }
          public bool Enabled { get; set; }
    
          //make it private set if you don't want an outsider setting it
          public Meta Properties {get;private set}
    
          public List<int> Items { get; set; }
      
     
          public class Meta
          {//make it private if you only create an instance here.
             internal Meta(){}
             public string Name { get; set; }
          }
        }
