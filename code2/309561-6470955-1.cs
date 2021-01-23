        public class MassiveSession : ISession
    { 
       
        ...
        public dynamic Find{
               get {
                   return new DynamicInvoker(this,name:"Find");
               }
        }
        public class DynamicInvoker : DynamicObject{
            ...
            public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
            {
                 ...
                 result = Impromptu.InvokeMember(Target,Name,invokeArgsArray);  
                 return true;          
            }
        }
    }
