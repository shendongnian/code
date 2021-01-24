    [HttpGet]
    public ActionResult DownloadCsv(string fileName)
    {
        string csv = TempData["Contents"] as string;
        string fileNameWithExt = fileName + ".csv";
        // check if the CSV content exists
        if (!string.IsNullOrEmpty(csv))
        {
            return File(new System.Text.UTF8Encoding.GetBytes(csv), "text/csv", fileNameWithExt);
        }
        else
        {
            return new EmptyResult();
        }
    }
