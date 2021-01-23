            public IEnumerable<HttpPostedFileBase> UploadedFiles { get; set; }
            var mailMessage = new MailMessage();
            // ... To, Subject, Body, etc
            foreach (var file in UploadedFiles)
            {
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        var attachment = new Attachment(file.InputStream, fileName);
                        mailMessage.Attachments.Add(attachment);
                    }
                    catch(Exception) { }
                }
            }
