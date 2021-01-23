    var destination = Path.GetTempFileName(); // you should probably replace this with a directory the IIS Worker Process has write permission to
    try {
    Request.Files[0].SaveAs(destination);
    
    Attachment.Add(new Attachment(destination));
    // Send attachment
    } finally {
    File.Delete(destination);
    }
