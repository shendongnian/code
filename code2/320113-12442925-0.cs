     public void Dispose()
        {
            if (this.MyProxy != null && this.MyProxy.State == CommunicationState.Faulted)
            {
                this.MyProxy.Abort();
                this.MyProxy.Close();
                this.MyProxy = null;
            }
            // ...more tidyup conditions here
        } 
