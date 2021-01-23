    System.IO.StringWriter sw = new System.IO.StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    Response.AddHeader("content-disposition", "attachment; filename=Avukat.xls");
    Response.ClearContent();
    
    Response.AddHeader("content-disposition", attachment);
    
    GridView1.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.Flush();
    Response.End();
