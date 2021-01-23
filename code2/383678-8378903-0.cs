        Response.Clear();
    Response.AddHeader("content-disposition","attachment;filename=Test.xls");   
    Response.ContentType = "application/ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
