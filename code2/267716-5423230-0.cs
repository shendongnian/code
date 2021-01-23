    public class SendReceiveInspector : IDispatchMessageInspector, IClientMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // TODO: Fire your event here if needed
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            // TODO: Fire your event here if needed
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // TODO: Fire your event here if needed
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // TODO: Fire your event here if needed
            return null;
        }
    }
