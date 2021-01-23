    public static Interface CreateOpenChannel<Interface>(Binding protocol, EndpointAddress address, int timeoutMs = 5000)
    {
        for (int startTime = Environment.TickCount;;) {
            // a proxy is unusable after comm failure ("faulted" state), so create it within the loop
            Interface proxy = ChannelFactory<Interface>.CreateChannel(protocol, address);
            try {
                ((IClientChannel) proxy).Open();
                return proxy;
            } catch (CommunicationException ex) {
                if (unchecked(Environment.TickCount - startTime) >= timeoutMs)
                    throw;
                Thread.Sleep(Math.Min(1000, timeoutMs / 4));
            }
        }
    }
