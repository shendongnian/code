    Response.Clear();
    Response.AddHeader("content-disposition","attachment;filename=myexcel.xls");   
    Response.ContentType = "application/ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    
    System.IO.StringWriter sw = new System.IO.StringWriter();
    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
    
    FormView1.RenderControl(hw);
    
    Response.Write(sw.ToString());
    Response.End();
