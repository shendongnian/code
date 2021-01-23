    public class DecoratorProxy<T> : RealProxy
    {
        private T m_instance;
        public static DecoratorProxy<T> CreateDecorator<T>(T instance)
        {
            return new DecoratorProxy<T>(instance);
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
            }
        }
    }
