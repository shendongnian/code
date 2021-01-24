    public ActionResult GetImage()
    {
      string fileName = "testFile.pdf";
      var pdfasBytes = ...;
      return File(pdfasBytes, "application/pdf", fileName);
    }
