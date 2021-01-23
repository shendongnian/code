    public ActionResult ShowPdf() {
        // Note: the view should contain a tag like <embed src='MyController/GetPdf'>
        return View(); 
    }
    public ActionResult GetPdf() {
        byte[] pdfBytes = dataRepo.GetPdf(...);
        return new PdfResult(pdfBytes, "Filename.pdf", false) ;
    } 
