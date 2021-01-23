    private static string RetrieveData(string url)
        {
            
            // used to build entire input
            var sb = new StringBuilder();
            // used on each read operation
            var buf = new byte[8192];
            try
            {
                // prepare the web page we will be asking for
                var request = (HttpWebRequest)
                                         WebRequest.Create(url);
               
               /* Using the proxy class to access the site
                * Uri proxyURI = new Uri("http://proxy.com:80");
                request.Proxy = new WebProxy(proxyURI);
                request.Proxy.Credentials = new NetworkCredential("proxyuser", "proxypassword");*/
                // execute the request
                var response = (HttpWebResponse)
                                           request.GetResponse();
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);
                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        // continue building the string
                        sb.Append(tempString);
                    }
                } while (count > 0); // any more data to read?
            }
            catch(Exception exception)
            {
                MessageBox.Show(@"Failed to retrieve data from the network. Please check you internet connection: " +
                                exception);
            }
            return sb.ToString();
        }
