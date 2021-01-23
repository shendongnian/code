        private T GetService<T>(Type type) where T : class
        {
            IServiceProvider hostServiceProvider = (IServiceProvider)Host;
            if (hostServiceProvider == null)
            {
                throw new Exception("Host property returned unexpected value (null)");
            }
            object serviceObj = hostServiceProvider.GetService(type);
            try
            {
                serviceObj = Marshal.GetObjectForIUnknown(Marshal.GetIUnknownForObject(serviceObj));
            }
            catch (Exception) { }
            T service = serviceObj as T;
            if (service == null)
            {
                throw new Exception("Unable to retrieve service");
            }
            return service;
        }
