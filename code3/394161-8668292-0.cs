    private void ServiceRequestInstanceHandler(IAsyncResult result)
    {
    try
        {
            // You should probably check for a null result here, just in case
            if(result == null)
            {
                throw new Exception("Result is null, cannot continue");
            }
            using (TcpClient client = _requestListener.EndAcceptTcpClient(result))
            {
                // Remember this line returns immediately/does not block
                _requestListener.BeginAcceptTcpClient(ServiceRequestInstanceHandler, _requestListener);
                ProcessRequest(client);
                client.Close();
            }
        }
        catch (Exception ex)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error("An error occured while processing a service request. ", ex);
        }
    }
