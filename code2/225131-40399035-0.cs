    response.ContentType = "application/vnd.ms-excel";
    response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
    response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
    response.Write("<head><style> td {mso-number-format:\\@;} </style></head><body>");
    
    using (StringWriter sw = new StringWriter())
    {
        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = ds.Tables[0];
            dg.DataBind();
            dg.RenderControl(htw);
            response.Write(sw.ToString());
            
            response.Write("</body></html>");
            response.End();
        }
    }   
