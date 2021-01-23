    //Set the appropriate ContentType.
    Response.ContentType = "Application/pdf";
    //Write the file content directly to the HTTP content output stream.
    Response.BinaryWrite(content)
    Response.End();
