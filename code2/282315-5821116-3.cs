    public class MEFServiceHostFactory : ServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, System.Uri[] baseAddresses)
        {
            var serviceType = MEF.Container
                .GetExports<IMessageBroker, IMessageBrokerMetadata>()
                .Where(l => l.Metadata.Name == constructorString)
                .Select(l => l.Value.GetType())
                .Single();
            var host = new ServiceHost(serviceType, baseAddresses);
            foreach (var contract in serviceType.GetInterfaces())
            {
                var attr = contract.GetCustomAttributes(typeof(ServiceContractAttribute), true).FirstOrDefault();
                if (attr != null)
                    host.AddServiceEndpoint(contract, new BasicHttpBinding(), "");
            }
            var metadata = host.Description.Behaviors
                .OfType<ServiceMetadataBehavior>()
                .FirstOrDefault();
            if (metadata == null)
            {
                metadata = new ServiceMetadataBehavior();
                metadata.HttpGetEnabled = true;
                host.Description.Behaviors.Add(metadata);
            }
            else
            {
                metadata.HttpGetEnabled = true;
            }
            return host;
        }
    }
