    public class SmartFilter
    {
        public int From  {get;set;}
        public int To  {get;set;}
        private List<SomeKnownType> collect  = new List<SomeKnownType>();
        public List<SomeKnownType> Collect { get { return collect; } }
        public long Bit {get;set;}
    }
