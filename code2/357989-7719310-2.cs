    public class ExpandedObject : DynamicObject
    {
        private readonly IDictionary<string, object> expando = new ExpandoObject();
    
        public ExpandedObject(object o)
        {            
            foreach (var propertyInfo in o.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                this.expando[propertyInfo.Name] = Impromptu.InvokeGet(o, propertyInfo.Name);
            }
        }
            
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {            
            return this.expando.TryGetValue(binder.Name, out result);
        }
    
        public override bool  TrySetMember(SetMemberBinder binder, object value)
        {
            this.expando[binder.Name] = value;
            return true;
        }
    }
