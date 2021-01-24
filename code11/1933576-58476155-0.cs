    [HttpPost]
    [Route("SubmitForm")]
    public async Task SubmitForm()
    {
        var file = Request.Body;
        HttpClient client = GetBinaryRequestClient();
        try
        {
            byte[] docAsBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                docAsBytes = ms.ToArray();
            }
            PdfReader pdfReader = new PdfReader(docAsBytes);
            MemoryStream m = new MemoryStream();
            PdfStamper outStamper = new PdfStamper(pdfReader,m);
            string formName = outStamper.AcroFields.GetField("FormSeqNo");
            string endpointUrl = string.Format(
               "{0}{1}/_api/web/GetFolderByServerRelativeUrl('{2}')/Files/Add(url='{3}', overwrite=true)",
               this.apiService.AppSettings.SharePointSettings.SPSiteURL,
               this.apiService.AppSettings.SharePointSettings.SmartFormsRelativeSiteURL,
               this.apiService.AppSettings.SharePointSettings.SubmittedPDFsLibrary,
               $"{formName}.pdf");
            ByteArrayContent imageBytes = new ByteArrayContent(docAsBytes);
            var result = await client.PostAsync(endpointUrl, imageBytes);
           Response.Redirect(this.apiService.AppSettings.SharePointSettings.SPSiteURL);
            //return Ok(); 
        }
        catch (Exception ex)
        {
            //return null;// StatusCode(StatusCodes.Status500InternalServerError, $"Error in method {ex.Message}");
            await ReturnFDFResponse("Error Occured " + ex.Message);
        }
    }
    private async Task ReturnFDFResponse(string status)
    {
        string fdfmessage = "%FDF-1.2" + "\n" + "1 0 obj <<" + "\n" + "/FDF <<" +
            "\n" + "/Status (" + status + "!)" + "\n" + ">>" + "\n" +
            ">>" + "\n" + "endobj" + "\n" + "trailer" + "\n" + "<</Root 1 0 R>>" +
            "\n" + "%%EOF";
        HttpResponseMessage fdfresult = new HttpResponseMessage(HttpStatusCode.OK);
        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(fdfmessage));
        stream.Position = 0;
        fdfresult.Content = new StreamContent(stream);
        fdfresult.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.fdf");
        Response.ContentType = "application/vnd.fdf";
        await Response.Body.WriteAsync(stream.ToArray());
    }
