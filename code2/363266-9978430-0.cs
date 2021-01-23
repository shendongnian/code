namespace ChannelFactoryCacheDemo
{
    public static class ChannelFactoryInitiator
    {
        private static Hashtable channelFactories = new Hashtable();
        public static ChannelFactory<T> Initiate<T>(string endpointName)
        {
            ChannelFactory<T> channelFactory = null;
            if (channelFactories.ContainsKey(endpointName))//already cached, get from the table
            {
                channelFactory = channelFactories[endpointName] as ChannelFactory<T>;
            }
            else // not cached, create and cache then
            {
                channelFactory = new ChannelFactory<T>(endpointName);
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[endpointName] = channelFactory;
                }
            }
            return channelFactory;
        }
    }
    class AppWhereUseTheChannel
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyContract> channelFactory = ChannelFactoryInitiator.Initiate<IMyContract>("MyEndpoint");
        }
    }
    interface IMyContract { }
}
