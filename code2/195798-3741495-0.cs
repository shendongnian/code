    private void Close()
    {
        if (channel != null &&
            channel.State == CommunicationState.Opened)
        {
            // If cannot cleanly close down the app in 3 seconds,
            // channel is locked due to channel heavily in use
            // through callbacks or the like.
            // Throw TimeoutException
            channel.Close(new TimeSpan(0, 0, 0, 3));
        }
    }
    public void Dispose()
    {
        // Dispose object
        if (channel != null)
        {
            try
            {
                // Close existing connections
                // *****************************
                // This is the close operation where we perform 
                //the channel close and timeout check and catch the exception.
                Close();
                // Attempt dispose object
                ((IDisposable)channel).Dispose();
            }
            catch (CommunicationException)
            {
                channel.Abort();
            }
            catch (TimeoutException)
            {
                channel.Abort();
            }
            catch (Exception)
            {
                channel.Abort();
                throw;
            }
        }
    }
