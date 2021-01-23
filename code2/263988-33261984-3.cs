    var memStream = new MemoryStream(yourPdfByteArray);
    memStream.Position = 0;
    var contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
    var reportAttachment = new Attachment(memStream, contentType);
    reportAttachment.ContentDisposition.FileName = "yourFileName.pdf";
    mailMessage.Attachments.Add(reportAttachment);
