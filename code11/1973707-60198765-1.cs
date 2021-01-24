    public class Year1 : IYear1
    {
        public int Test1 { get; set;}
    }
    
    public class Year2 : Year1, IYear2
    {
        public int Test2 { get; set; }
    }
