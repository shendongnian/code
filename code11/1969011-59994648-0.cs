    public static string GetIpAddressFromHttpRequest(HttpRequest httpRequest)
    {
      string ipAddressString = string.Empty;
      if (httpRequest == null)
      {
        return ipAddressString;
      }
      if (httpRequest.Headers != null && httpRequest.Headers.Count > 0)
      {
        if (httpRequest.Headers.ContainsKey("X-Forwarded-For") == true)
        {
          string headerXForwardedFor = httpRequest.Headers["X-Forwarded-For"];
          if (string.IsNullOrEmpty(headerXForwardedFor) == false)
          {
            string xForwardedForIpAddress = headerXForwardedFor.Split(':')[0];
            if (string.IsNullOrEmpty(xForwardedForIpAddress) == false)
            {
              ipAddressString = xForwardedForIpAddress;
            }
          }
        }
      }
      else if (httpRequest.HttpContext == null ||
           httpRequest.HttpContext.Connection == null ||
           httpRequest.HttpContext.Connection.RemoteIpAddress == null)
      {
           ipAddressString = httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
      }
      return ipAddressString;
    }
