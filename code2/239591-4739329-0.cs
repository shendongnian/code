    class Contact : DynamicObject
    {
        private readonly Dictionary<string, object> bag = new Dictionary<string, object>();
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public object this[string key]
        {
            get { return bag[key]; }
            set { bag[key] = value; }
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (bag.ContainsKey(binder.Name))
            {
                result = bag[binder.Name];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bag[binder.Name] = value;
            return true;
        }
    }
