     protected void ExportToExcel()
     {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=YourFiles.xls");
            Response.Charset = "";
            this.EnableViewState = false;
    
            System.IO.StringWriter sr = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw= new System.Web.UI.HtmlTextWriter(sr);
    
            gvFiles.RenderControl(htw);
    
            Response.Write(sw.ToString());
            Response.End();
        }
   
