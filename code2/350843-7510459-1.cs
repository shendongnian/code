    byte[] ar = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
    Response.ClearContent();
    Response.ClearHeaders();
    Response.AddHeader("Content-Type", "application/octet-stream");
    Response.AddHeader("Content-Length", ar.Length.ToString());
    Response.AddHeader("Content-Disposition", "attachment; filename=download.csv");
    Response.BinaryWrite(ar);
    Response.Flush();
    Response.End();
