    var bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/path/to/file.txt"));
    Response.AddHeader("Content-Type", "text/plain");
    Response.AddHeader("Content-Displosition", "attachment;filename=file.txt;size=" + bytes.Length);
    Response.Flush();
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
