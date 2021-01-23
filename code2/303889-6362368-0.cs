    class Proxy : System.Dynamic.DynamicObject
    {
        public Proxy(object someWrappedObject) { ... }
        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
        {
          // Do whatever, binder.Name will be the called method name
        }
    }
