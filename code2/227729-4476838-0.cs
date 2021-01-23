    private Stream GetNonFileStream(Uri uri, ICredentials credentials)
    {
        WebRequest request = WebRequest.Create(uri);
        if (credentials != null)
        {
            request.Credentials = credentials;
        }
        WebResponse response = request.GetResponse();
        HttpWebRequest request2 = request as HttpWebRequest;
        if (request2 != null)
        {
            lock (this)
            {
                if (this.connections == null)
                {
                    this.connections = new Hashtable();
                }
                OpenedHost host = (OpenedHost) this.connections[request2.Address.Host];
                if (host == null)
                {
                    host = new OpenedHost();
                }
                if (host.nonCachedConnectionsCount < (request2.ServicePoint.ConnectionLimit - 1))
                {
                    if (host.nonCachedConnectionsCount == 0)
                    {
                        this.connections.Add(request2.Address.Host, host);
                    }
                    host.nonCachedConnectionsCount++;
                    return new XmlRegisteredNonCachedStream(response.GetResponseStream(), this, request2.Address.Host);
                }
                return new XmlCachedStream(response.ResponseUri, response.GetResponseStream());
            }
        }
        return response.GetResponseStream();
    }
 
 
