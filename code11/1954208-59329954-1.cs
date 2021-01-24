    [HttpGet]       
    public HttpResponseMessage ExportExcelFile(string OriginalRequestNumber)
    {
        // ..
        var resultContent = _excelExport.Export(ObjectToExcel, "ExcelExport", true);
    
        var stream = new MemoryStream(resultContent);
     
        var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(stream) };
    
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "file.xlsx" };
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
    
        return response;
    } 
