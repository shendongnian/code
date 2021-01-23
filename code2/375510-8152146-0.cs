    byte []bytes=System.IO.File.ReadAllBytes(fileUrl);
    response.ClearHeaders();
    response.AddHeader("Content-Type","application/octet-stream");
    response.AddHeader("Content-Length",bytes.Length.ToString());
    response.AddHeader( "Content-Disposition", "attachment; filename=" + filename );
    response.BinaryWrite(bytes);
    response.Flush();
    response.End();
