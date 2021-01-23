    class StaticMethodProvider : DynamicObject
    {
        private Type ToWorkWith { get; set; }
    
        public StaticMethodProvider(Type toWorkWith)
        {
            ToWorkWith = toWorkWith;
        }
    
        public override bool TryInvokeMember(InvokeMemberBinder binder, 
            object[] args, out object result)
        {
            result = ToWorkWith.InvokeMember(binder.Name, BindingFlags.InvokeMethod, 
                null, null, null);
            return true;
        }
    }
