    internal class ConnectionProperties
    {
        internal string Name = "Default Name";
        internal bool Enabled = false;
    }
    
    internal class ConnectionProperties
    {
        internal string Name => "Default Name"; //makes them readonly
        internal bool Enabled => false;
        //omit above code
        public void Sth() {
             Name = "Hello"; //prints error -> cannot be assigned to -- it is read only
        }
    }
