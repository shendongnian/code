    public class CustomProxyFactoryFactory : IProxyFactoryFactory
    {
        NHibernate.ByteCode.Castle.ProxyFactoryFactory internalfactory = ...;
    
        public IProxyFactory BuildProxyFactory()
        {
            return internalfactory.BuildProxyFactory();
        }
     
        public bool IsInstrumented(Type entityClass)
        {
            return true;
        }
 
        public bool IsProxy(object entity)
        {
            return (entity is INHibernateProxy);
        }     
        public IProxyValidator ProxyValidator
        {
            get { return new CustomProxyValidator(); }
        }
    }
    
    public class CustomProxyValidator : DynProxyTypeValidator
    {
        private const bool iDontCare = true;
     
        protected override bool CheckMethodIsVirtual(Type type)
        {
            return iDontCare;
        }
    }
