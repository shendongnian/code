    public static class ServiceFactory
    {
            private WindsorContainer m_container;
            public static T GetServiceInstance<T>()
            {
                  // use your IOC to resolve your <T>
                   return m_container.Resolve<T>();
            }
    }
