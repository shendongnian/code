        /// <summary>
        /// Creates a service proxy from a binding name and address
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Create<T>()
        {
            string endpoint = ConfigurationManager.AppSettings["FactoryEndPointAddress"];
            string bindingname = ConfigurationManager.AppSettings["FactoryBindingName"];
            var address = new EndpointAddress(endpoint);
            var factory = new ChannelFactory<T>(GetBinding(bindingname), address);
            return factory.CreateChannel(address);
        }
