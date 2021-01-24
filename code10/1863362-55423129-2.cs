    [Route("GetspecificDocument")]
    [AllowAnonymous]
    public HttpResponseMessage GetspecificDocument(string searchText)
    {
        try
        {
            //DocumentMaster objFileReaderView = iEnquireyRepository.GetDocument(searchText);
            
            HttpResponseMessage ResponseDownload = new HttpResponseMessage(HttpStatusCode.OK);
    
            ResponseDownload.Content = GetDocument(searchText);
    
            if (objFileReaderView.Type.ToLower().Contains("pdf"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }
            else if (objFileReaderView.Type.ToLower().Contains("png"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            }
            else if (objFileReaderView.Type.ToLower().Contains("jpg") || objFileReaderView.Type.ToLower().Contains("jpeg"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }
            else if (objFileReaderView.Type.ToLower().Contains("csv"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/csv");
            }
            else if (objFileReaderView.Type.ToLower().Contains("doc"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");
            }
            else if (objFileReaderView.Type.ToLower().Contains("docx"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            else if (objFileReaderView.Type.ToLower().Contains("xlsx"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            else if (objFileReaderView.Type.ToLower().Contains("xls"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            }
            else if (objFileReaderView.Type.ToLower().Contains("zip"))
            {
                ResponseDownload.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
            }
            //ResponseDownload.Content.Headers.ContentDisposition.FileName = objFileReaderView.DocumentName;
            String reader = ResponseDownload.Content.ToString();
            return ResponseDownload;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    
    //Code for email
    public async static Task<bool> SendMail(string toAddress, string[] ccName, string subject, string body, string searchText)
    {
        try
        {
            
            string fromAddress = System.Configuration.ConfigurationManager.AppSettings["FromEmailAddr"];
    
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(fromAddress);
    
            msg.To.Add(new MailAddress(toAddress));
            foreach (string ccN in ccName)
            {
                msg.CC.Add(new MailAddress(ccN));
            }
            msg.Subject = subject;
            msg.Body = body;
    
            if(!string.IsNullOrEmpty(searchText))
            {
                var doc = GetDocument(searchText);
    
                var attachment = BuildAttachmentFromBlob(doc);
                
                msg.Attachments.Add(attachment);
            }
    
    
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Send(msg);
            return true;
        }
        catch (Exception ex)
        {
    
            return false;
        }
    }
    
    
    private ByteArrayContent GetDocument(string searchText)
    {
        long docid = Convert.ToInt64(searchText);
        DocumentMaster objFileReaderView = coreContext.DocumentMasters.Where(t => t.DocumentId == docid).FirstOrDefault();
    
        new ByteArrayContent(objFileReaderView.DocumentBinData)
    }
