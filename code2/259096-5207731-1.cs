            Uri uri = new Uri("https://mysite.com/auth");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
            request.Accept = "application/xml";
            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("user", "secret"));
            request.Credentials = cache;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            // response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
