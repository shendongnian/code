            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress("Your uri here");
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, address);
            IContract channel = factory.CreateChannel();
            channel.YourMethod();
            ((ICommunicationObject)channel).Close();
