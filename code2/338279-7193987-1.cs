    public ActionResult MyChart()
    {
        using (var client = new WebClient())
        {
            var data = client.DownloadData("http://......");
    
            // TODO: the MIME type might need adjustment
            return File(data, "image/png", "chart.png"); 
        }
    }
