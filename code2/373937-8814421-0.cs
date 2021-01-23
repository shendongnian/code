    protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
	{
		ServiceHost host = new ServiceHost(serviceType, baseAddresses);
		ContractDescription contract = ContractDescription.GetContract(serviceType);
		BasicHttpBinding binding = new BasicHttpBinding();
		binding.OpenTimeout = TimeSpan.FromMinutes(1);
		binding.ReceiveTimeout = TimeSpan.FromMinutes(1);
		binding.SendTimeout = TimeSpan.FromHours(1);
		binding.TransferMode = TransferMode.StreamedResponse;
		binding.MessageEncoding = WSMessageEncoding.Mtom;
		ServiceEndpoint streaming = new ServiceEndpoint(contract, binding, new EndpointAddress(baseAddresses[0] + "/STREAMING"));
		host.AddServiceEndpoint(streaming);
		return host;
	}
