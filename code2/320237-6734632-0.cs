    public class DepartmentsViewModel
        {
            public string title { get; set; }
    
            public string description { get; set; }
    
            public IEnumerable<Worker> workers { get; set; }
            //Additional ViewModel properties here
            //These may or may not be items that exist in your Model
        }
