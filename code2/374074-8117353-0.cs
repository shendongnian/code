    string filepath=MapPath("~/files/file.pdf");
    byte []bytes=System.IO.File.ReadAllBytes(filepath);
    
    Response.Clear();
    Response.ClearHeaders();
    Response.AddHeader("Content-Type", "application/octet-stream");
    Response.AddHeader("Content-Length", bytes.Length.ToString());
    Response.AddHeader("Content-Disposition","attachment; filename=file.pdf");
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
