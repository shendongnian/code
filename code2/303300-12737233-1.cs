    [ServiceBehavior]
    public class RoutingLogger : IYourInterface
    {
        public System.ServiceModel.Channels.Message YourInterfaceMethod(System.ServiceModel.Channels.Message message)
        {
            LogMessage(message);
            return new Custom404Message();
        }
    }
