    class Friend : Person
    {
        public Friend() : this("generic name") { }
        
        public Friend(String name)
        {
            this._name = name;
        }
        
        // now we override instance Person.GetName method:
        public override String GetName()
        {
            return _name;
        }
    }
