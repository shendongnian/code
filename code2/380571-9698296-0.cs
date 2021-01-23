    Try Adding : *htmlWrite.WriteLine(add);*
    
      string subject = lbl_Subj.Text;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearHeaders();
        Response.AddHeader("Cache-Control", "no-store, no-cache");        
        Response.AddHeader("content-disposition", "attachment;filename=" + subject + "-Status");
        Response.Charset = "";
        this.EnableViewState = false;    
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    
    **htmlWrite.WriteLine(add);**
    
        Grid_UserTable.RenderControl(htmlWrite);        
        rptList.RenderControl(htmlWrite);       
        Response.Write(stringWrite.ToString());     
        Response.End();
