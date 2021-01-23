    public static T GetFactoryChannel<T>(string address)
    {
        string key = typeof(T.Name);
        if (!OpenChannels.ContainsKey(key))
        {
            ChannelFactory<T> factory = new ChannelFactory<T>();
            factory.Endpoint.Address = new EndpointAddress(new System.Uri(address));
            factory.Endpoint.Binding = new BasicHttpBinding();
            OpenChannels.Add(key, factory);
        }
        T channel = ((ChannelFactory<T>)OpenChannels[key]).CreateChannel();
       
        ((IClientChannel)channel).Open();
        return channel;
    }
