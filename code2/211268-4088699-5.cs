       using (WebClient client = new WebClient())
       {
           byte[] response = client.UploadValues("http://dork.com/service", new NameValueCollection()
           {
               { "home", "Cosby" },
               { "favorite+flavor", "flies" }
           });
       }
