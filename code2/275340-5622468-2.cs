    protected void btnExport_Click(object sender, EventArgs e)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        string attachment = "attachment; filename=SummaryReport" + DateTime.Now.ToString() + ".xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        foreach (GridViewRow grdRow in grdProjectTasks.Rows)
        {
            Label lblActualDuration = (Label)grdRow.FindControl("lblActualDuration");
            lblActualDuration.Text = lblActualDuration.Text.Replace(":", ".");
        }
        grdProjectTasks.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
