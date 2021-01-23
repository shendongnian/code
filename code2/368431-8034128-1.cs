        public class Resource
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int InitialLevel { get; set; }
    //added by dx
            public new string ToString()
            {
                return Name;
            }
        }
    
