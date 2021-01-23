    class Foobar : DynamicObject 
    {
        private object m_object;
    
        public ExposedObjectSimple(object obj)
        {
            m_object = obj;
        }
    
        public override bool TryInvokeMember(
                InvokeMemberBinder binder, object[] args, out object result)
        {
            //Trying to find appropriate property
            var property = m_object.GetType().GetProperty("Name", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (property != null)
            {
                result = (string)property.GetValue(b, null);
                return true;
            }
            
            result = SomeDefaultName;
            return true;
        }
    }
