    public class MyClasseOne
    {
            public string AlertDescription { get; set; }
            public List<DropdownModel> AlertTypesList { get; set; }
            public long SelectedAlertType { get; set; }
            public List<DropdownModel> CustomersList { get; set; }
            public long SelectedCustomer { get; set; }
            public long[] SelectedProducts { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
    }
    
    public class MyClassTwo
    {
            public long[] SelectedProducts { get; set; }
            public List<DropdownModel> ProductList { get; set; }
    }
    
      public class MyViewModel
      {
        public MyClasseOne MyClasseOne { get; set; }
        public MyClassTwo MyClassTwo { get; set; }        
      }
    }
