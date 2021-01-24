    class Group 
    {
        private List<Member> _members;
        
        public string this
        {
            get
            {
                return _members.Find(m => m.Name == value);
            }
            // You can also implement set here if you want...
        }
    }
    
    class Member
    {
        private List<Property> _properties;
        
        public string Name {get;set;}
        
        public string this
        {
            get
            {
                return _properties.Find(m => m.Name == value);
            }
        }
    }
    
    class Property
    {
        public string Name {get;set;}
        
        public string Value {get;set;}
    }
