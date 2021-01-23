    public ActionResult Extracted(string url)
    {
        var extractedData = ExtractorService.Extract(url);
        if (extractedData != null)
        {
            return View(extractedData);
        }
        return RedirectToAction("Extract");
    }
