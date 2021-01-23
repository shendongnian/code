     public class DepartmentViewModel
            {
                public string title { get; set; }
        
                public string description { get; set; }
        
                public IEnumerable<Worker> workers { get; set; }
    
                //Additional ViewModel properties here
                //These may or may not be items that exist in your Model
    
                /// <summary>
                /// Mapped to the description but truncated to 10 characters and followed by an elispe (...)
                /// </summary>
                public string ShortDescription
                {
                    get
                    {
                        return description.Substring(0,10) + "...";
                    }
                }
        }
