        protected override WebRequest GetWebRequest(Uri uri) {
          WebRequest request = base.GetWebRequest(uri);
          string oAuthHeader = SignTheRequestAndGetTheOAuthHeader(request);
          if (!string.IsNullOrEmpty(oAuthHeader)) {
             request.Headers["Authorization"] = oAuthHeader;
          }
          return request;
        }
