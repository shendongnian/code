    protected string Request(
        string Method,
        Uri Endpoint,
        string[][] Headers,
        string Params) {
        try {
            ServicePointManager.Expect100Continue = false;
            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(Endpoint);
            Request.Method = Method;
            if (Method == "POST") {
                Request.ContentLength = Params.Length;
                Request.ContentType = "application/x-www-form-urlencoded";
            };
            for (byte a = 0, b = (byte)Headers.Length; a < b; a++) {
                Request.Headers.Add(Headers[a][0], Headers[a][1]);
            };
            if (!String.IsNullOrWhiteSpace(Params)) {
                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream())) {
                    Writer.Write(Params);
                };
            };
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointDelegate);
            using (StreamReader Reader = new StreamReader(Response.GetResponseStream())) {
                string R = Reader.ReadToEnd();
                try {
                    Mailer.Notification("<p>" + Endpoint.AbsoluteUri + "</p><p>" + Headers[0][1] + "</p><p>" + Params + "</p><p>" + R + "</p>");
                } catch (Exception) {
                    Mailer.Notification("<p>" + Endpoint.AbsoluteUri + "</p><p>" + Params + "</p><p>" + R + "</p>");
                };
                return (R);
            };
        } catch (WebException Ex) {
            try {
                if (Ex.Status != WebExceptionStatus.Success) {
                    using (StreamReader Reader = new StreamReader(Ex.Response.GetResponseStream())) {
                        string R = Reader.ReadToEnd();
                        try {
                            Mailer.Notification("<p>" + Endpoint.AbsoluteUri + "</p><p>" + Headers[0][1] + "</p><p>" + Params + "</p><p>" + R + "</p>");
                        } catch (Exception) {
                            Mailer.Notification("<p>" + Endpoint.AbsoluteUri + "</p><p>" + Params + "</p><p>" + R + "</p>");
                        };
                        return (R);
                    };
                };
            } catch (Exception) {
                //  Ignore
            };
            return (string.Empty);
        } catch (Exception) {
            return (string.Empty);
        };
    }
    private IPEndPoint BindIPEndPointDelegate(
        ServicePoint ServicePoint,
        IPEndPoint RemoteEndPoint,
        int Retries) {
        if (String.IsNullOrWhiteSpace(this.IPEndpoint)) {
            return new IPEndPoint(IPAddress.Any, 5000);
        } else {
            return new IPEndPoint(IPAddress.Parse(this.IPEndpoint), 5000);
        };
    }
