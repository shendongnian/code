    namespace Common.Infrastructure.WCF
    {
        class NHibernateContextManager : IExtension<InstanceContext>
        {
            public IDictionary<ISessionFactory, Lazy<ISession>> SessionFactoryMaps = new Dictionary<ISessionFactory, Lazy<ISession>>();
    
            public void Attach(InstanceContext owner)
            {
                //We have been attached to the Current operation context from the ServiceInstanceProvider
            }
    
            public void Detach(InstanceContext owner)
            {
            }
        }
    }
