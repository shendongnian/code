            var request = WebRequest.Create(url);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            try
            {
                using(var response = (FtpWebResponse)request.GetResponse())
                {
                    // file exists
                }
            }
            catch(WebException e)
            {
                // file probably doesn't exits
            }
