        public void InvokeService<T>(Binding binding, string endpointAddress, Action<T> invokeHandler) where T : class
        {
            T channel = FactoryManager.CreateChannel<T>(binding, endpointAddress);
            ICommunicationObject communicationObject = (ICommunicationObject)channel;
            try
            {
                invokeHandler(channel);
            }
            finally
            {
                try
                {
                    if (communicationObject.State != CommunicationState.Faulted)
                    {
                        communicationObject.Close();
                    }
                }
                catch
                {
                    communicationObject.Abort();
                }
            }
        }
