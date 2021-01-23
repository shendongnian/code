    internal interface IInternalInterface {
        void SayHello();
    }
    // --------------------------------------------------------------
    // in another assembly
    public class ImplementationProxy : RealProxy, IRemotingTypeInfo {
        private readonly MethodInfo method;
        
        public ImplementationProxy(MethodInfo method) 
            : base(typeof(ContextBoundObject))
        {
            this.method = method;
        }
        public override IMessage Invoke(IMessage msg) {
            if (!(msg is IMethodCallMessage))
                throw new NotSupportedException();
            var call = (IMethodCallMessage)msg;
            if (call.MethodBase != this.method)
                throw new NotSupportedException();
            Console.WriteLine("Hi from internals!");
            return new ReturnMessage(null, null, 0, call.LogicalCallContext, call);
        }
        public bool CanCastTo(Type fromType, object o)
        {
            return fromType == method.DeclaringType;
        }
 
        public string TypeName
        {
            get { return this.GetType().Name; }
            set { }
        }
    }    
