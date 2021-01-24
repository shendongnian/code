        public class MonthModel
        {
            public List<string> sun { get; set; } = new List<string>();
            public List<string> mon { get; set; } = new List<string>();
            public List<string> tue { get; set; } = new List<string>();
            public List<string> wed { get; set; } = new List<string>();
            public List<string> thu { get; set; } = new List<string>();
            public List<string> fri { get; set; } = new List<string>();
            public List<string> sat { get; set; } = new List<string>();
    
    
            public string Sunday
            {
                get
                {
                    return string.Join(",", sun);
                }
            }
        }
