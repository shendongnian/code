    class Person
    {
        // this one is not overridable (not virtual)
        public String GetPersonType()
        {
            return "person";
        }
        
        // this one is overridable (virtual)
        public virtual String GetName()
        {
            return "generic name";
        }
    }
