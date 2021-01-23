    public void Close()
    {
        // Attempt to avoid exception by doing initial state check
        if (this.channel.State == CommunicationState.Opened)
        {
            try
            {
                // Now we must do a (potentially) remote call;
                // this could always throw.
                this.channel.Close();
            }
            catch (CommunicationException)
            {
            }
            catch (TimeoutException)
            {
            }
        }
    
        // If Close failed, we might need to do final cleanup here.
        if (this.channel.State == CommunicationState.Faulted)
        {
            // local cleanup -- never throws (aside from catastrophic situations)
            this.channel.Abort();
        }
    }
