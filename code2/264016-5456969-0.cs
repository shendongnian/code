            WebRequest webRequest = WebRequest.Create(url);
            HttpWebRequest httpWebRequest = webRequest as HttpWebRequest;
            // request authentication
            httpWebRequest.UseDefaultCredentials = true;
            // which is the same as
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            // optional proxy authentication
            httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
