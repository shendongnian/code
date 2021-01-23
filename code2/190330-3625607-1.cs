    Response.Clear();
    MemoryStream ms = new MemoryStream(pdfByte);
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=labtest.pdf");
    Response.Buffer = true;
    ms.WriteTo(Response.OutputStream);
    Response.End();
