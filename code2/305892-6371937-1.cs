    internal class UnknownOperationInvoker : IOperationInvoker
    {
        public object[] AllocateInputs()
        {
            return new object[1];
        }
        private Message CreateTextMessage(string message)
        {
            Message result = Message.CreateMessage(MessageVersion.None, null, new HelpPageGenerator.TextBodyWriter(message));
            result.Properties["WebBodyFormatMessageProperty"] = new WebBodyFormatMessageProperty(WebContentFormat.Raw);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return result;
        }
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            // Code HERE
                    StringBuilder builder = new System.Text.StringBuilder();
                    builder.Append("...");
                    Message result = CreateTextMessage(builder.ToString());
                    return result;
        }
        public System.IAsyncResult InvokeBegin(object instance, object[] inputs, System.AsyncCallback callback, object state)
        {
            throw new System.NotImplementedException();
        }
        public object InvokeEnd(object instance, out object[] outputs, System.IAsyncResult result)
        {
            throw new System.NotImplementedException();
        }
        public bool IsSynchronous
        {
            get { return true; }
        }
    }
