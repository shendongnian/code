        HttpWebRequest Request = WebRequest.CreateHttp(BaseAddress.Uri);
        if (!string.IsNullOrWhiteSpace(method))
          Request.Method = method;
        else
          Request.Method = "GET";
        Request.Headers.Add("Authorization", BasicAuthInfo);
        Request.Accept = "application/json";
        if (!string.IsNullOrWhiteSpace(body))
        {
          UTF8Encoding encoding = new UTF8Encoding();
          byte[] byteBody = encoding.GetBytes(body);
          Request.ContentLength = byteBody.Length;
          using (Stream dataStream = Request.GetRequestStream())
            dataStream.Write(byteBody, 0, byteBody.Length);
          if (string.IsNullOrEmpty(Request.ContentType))
            Request.ContentType = "application/json";
        }
