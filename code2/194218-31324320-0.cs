     WindowsIdentity wi = null;
     wi = (WindowsIdentity)HttpContext.Current.User.Identity;
     using (wi.Impersonate())
           {
             var client = new WebClient { UseDefaultCredentials = true };
             client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                var result = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(client.DownloadData("http://api.com/api/values")));
             return Request.CreateResponse(result);
           }
