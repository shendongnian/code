     static bool TestConnection(string ipAddress, int Port, TimeSpan waitTimeSpan)
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    IAsyncResult result = tcpClient.BeginConnect(ipAddress, Port, null, null);
                    WaitHandle timeoutHandler = result.AsyncWaitHandle;
                    try
                    {
                        if (!result.AsyncWaitHandle.WaitOne(waitTimeSpan, false))
                        {
                            tcpClient.Close();
                            return false;
                        }
    
                        tcpClient.EndConnect(result);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        timeoutHandler.Close();
                    }
                    return true;
                }
            }
