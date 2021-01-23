    HttpWebResponse RetryGetResponse(HttpWebRequest request)
    {
        while (true)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.ReceiveFailure &&
                    ex.Status != WebExceptionStatus.ConnectFailure &&
                    ex.Status != WebExceptionStatus.KeepAliveFailure)
                {
                    throw;
                }
            }
        }
    }
