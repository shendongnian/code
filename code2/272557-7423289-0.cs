	public class SoapServiceHostFactory : ServiceHostFactory
	{
		private Type serviceInterfaceType;
		public SoapServiceHostFactory(Type serviceInterfaceType) 
		{
			this.serviceInterfaceType = serviceInterfaceType;
		}
		protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
			host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
			host.AddServiceEndpoint(serviceInterfaceType, new BasicHttpBinding(), "soap");
			return host;
		}
	}
