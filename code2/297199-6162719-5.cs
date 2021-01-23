    class Friend : Person
    {
        public Friend() : this("generic name") { }
        
        public Friend(String name)
        {
            this._name = name;
        }
        
        // override Person.GetName:
        public override String GetName()
        {
            return _name;
        }
    }
