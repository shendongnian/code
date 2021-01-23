        public static Stream GetExternalData( string url, string postData, int timeout )
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate( object sender,
                                                                                    X509Certificate certificate,
                                                                                    X509Chain chain,
                                                                                    SslPolicyErrors sslPolicyErrors )
            {
                // if we trust the callee implicitly, return true...otherwise, perform validation logic
                return [bool];
            };
            WebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = WebRequest.Create( url );
                request.Timeout = timeout; // force a quick timeout
                if( postData != null )
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = postData.Length;
                    using( StreamWriter requestStream = new StreamWriter( request.GetRequestStream(), System.Text.Encoding.ASCII ) )
                    {
                        requestStream.Write( postData );
                        requestStream.Close();
                    }
                }
                response = (HttpWebResponse)request.GetResponse();
            }
            catch( WebException ex )
            {
                Log.LogException( ex );
            }
            finally
            {
                request = null;
            }
            if( response == null || response.StatusCode != HttpStatusCode.OK )
            {
                if( response != null )
                {
                    response.Close();
                    response = null;
                }
                return null;
            }
            return response.GetResponseStream();
        }
