			IService1 channel = null;
			try {
				BasicHttpBinding binding = new BasicHttpBinding();
				EndpointAddress address = new EndpointAddress("http://192.168.30.88:8731/Design_Time_Addresses/WcfServiceLibrary1/Service1/");
				IChannelFactory<IService1> factory = binding.BuildChannelFactory<IService1>(new BindingParameterCollection());
				channel = factory.CreateChannel(address);
				// Use the channel here...
			}
			finally {
				if(channel != null && ((ICommunicationObject)channel).State == CommunicationState.Opened) {
					((ICommunicationObject)channel).Close();
				}
			}
