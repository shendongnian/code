    bool IsResourceModified(string url, DateTime dateTime) {			
        try {
            var request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.IfModifiedSince = dateTime;
            request.Method = "HEAD";
            var response = (HttpWebResponse)request.GetResponse();
            
            return true;
        }
        catch(WebException ex) {
            if(ex.Status != WebExceptionStatus.ProtocolError)
                throw;
            
            var response = (HttpWebResponse)ex.Response;
            if(response.StatusCode != HttpStatusCode.NotModified)
                throw;
            
            return false;    
        }
    }
