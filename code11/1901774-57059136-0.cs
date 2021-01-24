    public class Dates {
        public string Year {get; set;}
        public List<Months> Months {get; set;}
    }
    
    public class Months {
        public string Month {get; set;}
        public List<Day> Days {get; set;}
    }
    
    public class Days {
        public string Day { get; set; }
    }
