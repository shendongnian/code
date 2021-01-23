    using System.ServiceModel.Dispatcher;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    namespace your.namespace.here
    {
        public class UnknownUriDispatcher : IOperationInvoker
        {
            public object[] AllocateInputs()
            {
                //no inputs are really going to come in,
                //but we want to provide an array anyways
                return new object[1]; 
            }
    
            public object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                var responeObject = new YourResponseObject()
                {
                    Message = "Invalid Uri",
                    Code = "Error",
                };
                Message result = Message.CreateMessage(MessageVersion.None, null, responeObject);
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
                outputs = new object[1]{responeObject};
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
    }
