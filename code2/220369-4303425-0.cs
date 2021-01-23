    public class ClientMessageLogger : IClientMessageInspector
    {
        public void AfterReceiveReply(
            ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Do nothing.
        }
    
        public object BeforeSendRequest(
            ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            // Create a buffer.
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            // Set the request reference to an unspoiled clone.
            request = buffer.CreateMessage();
            // Make another unspoiled clone to process (taint) locally within this method.
            Message originalMessage = buffer.CreateMessage();
    
            // Log the SOAP xml.
            Log(originalMessage.ToString());
    
            return null;
        }
    }
