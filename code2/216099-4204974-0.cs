    private void SendFormatted(Outlook.MailItem mail)
        {
            if (!string.IsNullOrEmpty(mail.HTMLBody) && mail.HTMLBody.ToLower().Contains("</body>"))
            {
                //Get Image + Link
                string imagePath = @"D:\\Media\Imagenes\100MSDCF\DSC00632.JPG";
                object linkAddress = "http://www.pentavida.cl";
                //CONTENT-ID
                const string SchemaPR_ATTACH_CONTENT_ID = @"http://schemas.microsoft.com/mapi/proptag/0x3712001E";
                string contentID = Guid.NewGuid().ToString();
                //Attach image
                mail.Attachments.Add(imagePath, Outlook.OlAttachmentType.olByValue, mail.Body.Length, Type.Missing);
                mail.Attachments[mail.Attachments.Count].PropertyAccessor.SetProperties(SchemaPR_ATTACH_CONTENT_ID, contentID);
                //Create and add banner
                string banner = string.Format(@"<br/><a href=""{0}"" ><img src=""cid:{1}"" ></a></body>", linkAddress, contentID);
                mail.HTMLBody = mail.HTMLBody.Replace("</body>", banner);
                mail.Save();
            }
        }
