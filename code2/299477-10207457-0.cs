        /// <summary>
        /// Gets the file lenght from location.
        /// </summary>
        /// <param name="location">The location where file location sould be located.</param>
        /// <returns>Lenght of the content</returns>
        public int GetFileLenghtFromUrlLocation(string location)
        {
            int len = 0;
            int timeoutInSeconds = 5;
            // paranoid check for null value
            if (string.IsNullOrEmpty(location)) return 0;
            // Create a web request to the URL
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(location);
            myRequest.Timeout = timeoutInSeconds * 1000;
            myRequest.AddRange(1024);
            try
            {
                // Get the web response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                // Make sure the response is valid
                if (HttpStatusCode.OK == myResponse.StatusCode)
                {
                    // Open the response stream
                    using (Stream myResponseStream = myResponse.GetResponseStream())
                    {
                        if (myResponseStream == null) return 0;
                        using (StreamReader rdr = new StreamReader(myResponseStream))
                        {
                            len = rdr.ReadToEnd().Length;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error saving file from URL:" + err.Message, err);
            }
            return len;
        }
