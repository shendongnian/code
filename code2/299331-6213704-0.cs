    System.IO.StringWriter sw = new System.IO.StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
    Response.ClearContent();
    
    Response.AddHeader("content-disposition", attachment);
    
    dg.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.Flush();
    Response.End();
