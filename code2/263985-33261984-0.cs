    var memStream = New MemoryStream(yourPdfByteArray);
    memStream.Position = 0;
    var contentType = New System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
    var reportAttachment = New Attachment(memStream, contentType);
    reportAttachment.ContentDisposition.FileName = "yourFileName.pdf";
    mailMessage.Attachments.Add(reportAttachment);
