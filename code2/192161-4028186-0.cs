        public static IUnityContainer GetContainer(this HttpApplicationState application)
        {
            IUnityContainer container = application[GlobalContainerKey] as IUnityContainer;
            if (container == null)
            {
                application.Lock();
                try
                {
                    container = application[GlobalContainerKey] as IUnityContainer;
                    if (container == null)
                    {
                        container = new UnityContainer();
                        application[GlobalContainerKey] = container;
                    }
                }
                finally
                {
                    application.UnLock();
                }
            }
            return container;
        }
