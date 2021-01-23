    public class Parent
    {
        protected string _id;
        // Protected default constructor so tht this class can be inherited:
        protected Parent() { }
        // REquired to set ID at initialization; 
        public Parent(String ID)
        {
            _id = ID;
        }
        // Read-only:
        public String ID
        {
            get { return _id; }
        }
        // This seems a little dodgy. Why would you want to return a reference
        // to the current instance as a result of resetting the ID?
        public Parent SetID(String ID)
        {
            _id = ID;
            return this;
        }
    }
