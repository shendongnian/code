    public class myList 
    { 
        public int ID { get; set; } 
        public string M { get; set; } 
        public class myInternalList
        {
        public string X { get; set; } 
        public string Y { get; set; } 
        public string Z { get; set; } 
        }
        public List<myInternalList> theList = new List<myInternalList>();
    } 
