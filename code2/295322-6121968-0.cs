     protected void btnExport_Click(object sender, EventArgs e)
    {
    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    string attachment = "attachment; filename=FileName" + DateTime.Now.ToString() + ".xls";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/ms-excel";
     foreach (RepeaterItem item in Repeater1.Items)
    {
       CheckBox chk= item.FindControl("CheckBox") as CheckBox;
       chk.Visible = false;
    }
    Repeater1.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.End();
}
