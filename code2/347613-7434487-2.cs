    bool SendMessage()
    {
        // acquire semaphore. This will block until there's a slot available.
        mailSendSemaphore.WaitOne();
        try
        {
            // do all your processing here, including sending the message.
            // use Send rather than SendAsync
        }
        finally
        {
            mailSendSemaphore.Release();
        }
    }
