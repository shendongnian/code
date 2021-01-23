    public class Child : Parent
    {
        private string _name;
        // Protected default constructor so tht this class can be inherited:
        protected Child() { }
        // Initialize a new Child with the ID property required for the parent:
        public Child(String ID)
        {
            base.SetID(ID);
        }
        // Initialize a new child with both properties set:
        public Child(String ID, String Name) : this(ID)
        {
            _name = Name;
        }
        // This could be read-only as well:
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // Again, seems kinda dodgy: 
        public Child SetName(String name)
        {
            return this;
        }
    }
