    public class DecoratorProxy<T> : RealProxy
    {
        private T m_instance;
        public static T CreateDecorator<T>(T instance)
        {
            var proxy = new DecoratorProxy<T>(instance);
            (T)proxy.GetTransparentProxy();
        }
        private DecoratorProxy(T instance) : base(typeof(T))
        {
            m_instance = instance;
        }
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodMessage = msg as IMethodCallMessage;
            if (methodMessage != null)
            {
                // log method information
                //call method
                methodMessage.MethodBase.Invoke(m_instance, methodMessage.Args);
                return new ReturnMessage(retval, etc,etc);
            }
        }
    }
