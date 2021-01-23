    private void CreateListener
    {
        HttpListener listener = null;
        HttpListenerContext context = null;
        HttpListenerRequest request = null;
        HttpListenerResponse response = null;
        string PortNumber = "9876";
        string requestUrl;
        Boolean listen = false;
    
        try
        {
            if (listener == null)
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://*:" + PortNumber + "/");
                listener.Start();
                listen = true;
                while (listen)
                {
                    try
                    {
                        context = listener.GetContext();
                    }
                    catch (Exception e)
                    {
                        listen = false;
                    }
                    if (listen)
                    {
                        request = context.Request;
                        requestUrl = request.Url.ToString();
    
                        // Process request and/or request Url
                    }
                }
            }
        }
    }
