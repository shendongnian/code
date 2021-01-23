            public void ToPdf(string uco, int idAudit)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= Document.pdf");
            Response.Buffer = true;
            Response.Clear();
            //get the memorystream pdf
            var bytes = new MisAuditoriasLogic().ToPdf(uco, idAudit).ToArray();
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
        
        }
        public ActionResult ToMail(string uco, string filter, int? page, int idAudit, int? full) 
        {
            //get the memorystream pdf
            var bytes = new MisAuditoriasLogic().ToPdf(uco, idAudit).ToArray();
            using (var stream = new MemoryStream(bytes))
            using (var mailClient = new SmtpClient("**YOUR SERVER**", 25))
            using (var message = new MailMessage("**SENDER**", "**RECEIVER**", "Just testing", "See attachment..."))
            {
                stream.Position = 0;
                Attachment attach = new Attachment(stream, new System.Net.Mime.ContentType("application/pdf"));
                attach.ContentDisposition.FileName = "test.pdf";
                message.Attachments.Add(attach);
                mailClient.Send(message);
            }
            ViewBag.errMsg = "Documento enviado.";
            return Index(uco, filter, page, idAudit, full);
        }
