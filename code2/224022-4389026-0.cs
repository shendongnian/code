    private static bool GetResponse(NetworkStream stream, out string response)
    {
        byte[] readBuffer = new byte[32];
        var asyncReader = stream.BeginRead(readBuffer, 0, readBuffer.Length, null, null);
        WaitHandle handle = asyncReader.AsyncWaitHandle;
    
        // Give the reader 2seconds to respond with a value
        bool completed = handle.WaitOne(2000, false);
        if (completed)
        {
            int bytesRead = stream.EndRead(asyncReader);
    
            StringBuilder message = new StringBuilder();
            message.Append(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));
    
            if (bytesRead == readBuffer.Length)
            {
                // There's possibly more than 32 bytes to read, so get the next section
                // of the response
                string continuedResponse;
                if (GetResponse(stream, out continuedResponse))
                {
                    message.Append(continuedResponse);
                }
            }
    
            response = message.ToString();
            return true;
        }
        else
        {
            int bytesRead = stream.EndRead(asyncReader);
            if (bytesRead == 0)
            {
                // 0 bytes were returned, so the read has finished
                response = string.Empty;
                return true;
            }
            else
            {
                throw new TimeoutException(
                    "The device failed to read in an appropriate amount of time.");
            }
        }
    }
