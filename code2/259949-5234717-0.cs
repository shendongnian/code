    protected void btnExportExl_Click(object sender, EventArgs e)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        string attachment = "attachment; filename=BusinessUnit.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        GridView grd = new GridView();
        grd.DataSource = datatable.DefaultView; // you get the datatable from DB that will not have controls!!!
        grd.DataBind();
        grd.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
