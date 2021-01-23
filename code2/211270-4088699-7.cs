       using (WebClient client = new WebClient())
       {
           byte[] response =
           client.UploadValues("http://dork.com/service", new NameValueCollection()
           {
               { "home", "Cosby" },
               { "favorite+flavor", "flies" }
           });
           string result = System.Text.Encoding.UTF8.GetString(response);
       }
