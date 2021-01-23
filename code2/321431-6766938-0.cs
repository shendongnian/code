    public static ChannelFactory<TContract> NewChannelFactory<TContract>(string endpointConfigurationName) where TContract : class {
        // TODO: Cache the factory in here for better performance.
        return new ChannelFactory<TContract>(endpointConfigurationName);
    }
    public static void Invoke<TContract>(ChannelFactory<TContract> factory, Action<TContract> action) where TContract : class {
        var proxy = (IClientChannel) factory.CreateChannel();
        bool success = false;
        try {
            action((TContract) proxy);
            proxy.Close();
            success = true;
        } finally {
            if(!success) {
                proxy.Abort();
            }
        }
    }
