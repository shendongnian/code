    private string ExecuteRequest(Uri url, KeyValuePair<string, string>[] postItems = null)
    {
        var data = new byte[0];
        var response = new byte[0];
        ///switched to WebClient because
        /// http://stackoverflow.com/questions/8167726/monodroid-intermittent-failure-when-reading-a-large-json-string-from-web-servi
        using (var client = new WebClient())
        {
            if (postItems != null && postItems.Count() > 0)
            {
                string dataString = string.Join("&", postItems.Select(
                                        item => string.Format("{0}={1}", item.Key, item.Value)).ToArray());
                data = new ASCIIEncoding().GetBytes(dataString);
            }
            response = client.UploadData(url, "POST", data);
            Android.Util.Log.Info("info", "response from the post received. about to get string");
            client.Dispose();
        }
        try
        {
            Android.Util.Log.Info("info", "response size : {0}", response.Length);
            var chunkSize = 50000;
            if (response.Length > chunkSize)
            {
                var returnValue = new StringBuilder();
                for (int i = 0; i < response.Length; i+= chunkSize)
                {                        
                    int end = (i + chunkSize) > response.Length ? response.Length - i : chunkSize;
                    returnValue.Append(Encoding.ASCII.GetString(response, i, end));
                    Android.Util.Log.Info("info", "added a chunk from {0} to {1}", i, end);
                }
                return returnValue.ToString();
            }
            return Encoding.ASCII.GetString(response);
        }
        catch (Exception ex)
        {
            Android.Util.Log.Info("info", 
                "Encoding.ASCII.GetString Exception : {0}, {1}", ex.Message, ex.StackTrace);
            throw new ApplicationException("UnRecoverable. Abort");
        }            
    }
