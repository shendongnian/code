      public static string downloadcontent(string urlofpage)
            {
                WebClient client = new WebClient();
    
                string content = client.DownloadString(urlofpage);
    
                return content;
            }
