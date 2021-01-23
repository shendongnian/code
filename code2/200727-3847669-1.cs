    public class TestEventArgs : EventArgs
    {    
        public String OldString { get; private set; }
        public String NewString { get; private set; }
    
        public TestEventArgs(String oldString, String newString)
        {
            this.OldString = oldString;
            this.NewString - newString
        }
    }
