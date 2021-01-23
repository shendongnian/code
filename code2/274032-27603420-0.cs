    Response.Clear();
    Response.ContentType = "Application/x-msexcel";
    Response.AddHeader("content-disposition", "attachment; filename=\"filename.csv\"");
    Response.ContentEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
    Response.Write(string.Join(";", myDataLines));
    Response.End();
