    public Boolean ValidateSignature(String method, Uri url)
            {
                String normalizedUrl, normalizedRequestParameters;
    
                List<QueryParameter> parameters = new List<QueryParameter>();
                parameters.AddRange(GetQueryParameters(url.Query));
    
                var sigParam = parameters.Find(p => p.Name == OAuthSignatureKey);
                if (sigParam == null)
                    return false;
                var expected = sigParam.Value;
    
                parameters.Remove(parameters.Find(p => p.Name == OAuthSignatureKey));
                parameters.Sort(new QueryParameterComparer());
    
                normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
                if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
                {
                    normalizedUrl += ":" + url.Port;
                }
                normalizedUrl += url.AbsolutePath;
                normalizedRequestParameters = NormalizeRequestParameters(parameters);
    
                StringBuilder signatureBase = new StringBuilder();
                signatureBase.AppendFormat("{0}&", method.ToUpper());
                signatureBase.AppendFormat("{0}&", UrlEncode(normalizedUrl));
                signatureBase.AppendFormat("{0}", UrlEncode(normalizedRequestParameters));
    
                HMACSHA1 hmacsha1 = new HMACSHA1();
                hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", UrlEncode(ConsumerSecret), ""));//string.IsNullOrEmpty(tokenSecret) ? "" : UrlEncode(tokenSecret)));
    
                var computed = GenerateSignatureUsingHash(signatureBase.ToString(), hmacsha1);
                return expected == UrlEncode(computed);
            } 
