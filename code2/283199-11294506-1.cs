    public static string getProjects()
        {
            string uri = "https://<companyname>.harvestapp.com/projects";
            HttpClient http = new HttpClient();
            //Http Header
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            http.Request.ContentType = HttpContentTypes.ApplicationJson;
            http.Request.SetBasicAuthentication(username, password);
            http.Request.ForceBasicAuth = true;
            HttpResponse response = http.Get(uri);
            return response.RawText;        
        }
