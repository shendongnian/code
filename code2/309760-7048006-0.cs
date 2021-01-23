    public class NoMessageSizeLimitHostConfig : HttpConfigurableServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var host = base.CreateServiceHost(serviceType, baseAddresses);  
            foreach (var endpoint in host.Description.Endpoints)
            {
                var binding = endpoint.Binding as HttpBinding;    
                if (binding != null)
                {
                    binding.MaxReceivedMessageSize = Int32.MaxValue;
                    binding.MaxBufferPoolSize = Int32.MaxValue;
                    binding.MaxBufferSize = Int32.MaxValue;
                    binding.TransferMode = TransferMode.Streamed;
                }
            }
            return host;
        }
    }
