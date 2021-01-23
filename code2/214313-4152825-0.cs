    public class YourClass
    {
        // Constructor logic should be here
        public YourClass Copy() { return CopyClone(); }        
        public YourClass Clone() { return CopyClone(); }
        private YourClass CopyClone() { return new YourClass(ID, Name, Dept); }
    }
