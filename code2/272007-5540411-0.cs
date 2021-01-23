    public class DependencyInjectionProxy : RealProxy
    {
        private object realInstance;
        public DependencyInjectionProxy(Type classToProxy, 
            object realInstance) : base(classToProxy)
        {
            this.realInstance = realInstance;
        }
        public static T MakeProxy<T>(T realInstance)
        {
            return (T)(new DependencyInjectionProxy(typeof(T),
                realInstance).GetTransparentProxy());
        }
        public override IMessage Invoke(IMessage msg)
        {
            if (msg is IMethodCallMessage)
            {
                var message = (IMethodCallMessage)msg;
                
                object value = message.MethodBase.Invoke(
                    this.realInstance, message.Args);
                Console.WriteLine(value);
                return new ReturnMessage(value, null, 0, null, message);
            }
            return msg;
        }
    }
