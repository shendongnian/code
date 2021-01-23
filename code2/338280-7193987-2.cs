    public ActionResult MyChart()
    {
        using (var client = new WebClient())
        {
            var request = new NameValueCollection
            {
                { "foo", "foo value" },
                { "bar", "bar value" },
            };
            var data = client.UploadValues("http://......", request);
    
            // TODO: the MIME type might need adjustment
            return File(data, "image/png", "chart.png"); 
        }
    }
