    protected void Application_Start()
        {
            ...
            //Add LargeJsonValueProviderFactory
            ValueProviderFactory jsonFactory = null;
            foreach (var factory in ValueProviderFactories.Factories)
            {
                if (factory.GetType().FullName == "System.Web.Mvc.JsonValueProviderFactory")
                {
                    jsonFactory = factory;
                    break;
                }
            }
            if (jsonFactory != null)
            {
                ValueProviderFactories.Factories.Remove(jsonFactory);
            }
            var largeJsonValueProviderFactory = new LargeJsonValueProviderFactory();
            ValueProviderFactories.Factories.Add(largeJsonValueProviderFactory);
        }
