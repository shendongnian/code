    public class Schedule {
        public int From;
        public int To;
        public int TotalHours => To - From;
        public string Type;
    
        public Schedule(int from, int to, string type) {
            From = from;
            To = to;
            Type = type;
        }
    }
    
    public class Register {
        public int From;
        public int To;
    
        public Register(int from, int to) {
            From = from;
            To = to;
        }
    }
