    public ActionResult Download()
    {
        string url = (string)TempData["url"];
    
        using (WebClient client = new WebClient())
        {
           // Download data.
           byte[] thePdf = client.DownloadData("http://url-to-your-pdf-file.com/file1");
           return File(thePdf,"application/pdf");
        }
    }
