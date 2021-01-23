                   //Clear the controls inside the parent grid-view before render.
                    gvExportToExcel.DataSource = objDs;
                    gvExportToExcel.DataBind();           
                    System.Web.HttpContext curContext = System.Web.HttpContext.Current;
                    System.IO.StringWriter strWriter = null;
                    System.Web.UI.HtmlTextWriter htmlWriter = null;                       
                    curContext.Response.Clear();
                    curContext.Response.Buffer = true;
                    curContext.Response.AddHeader("content-disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode("SearchSubmissionResult", System.Text.Encoding.UTF8) + ".xls");
                    curContext.Response.ContentType = "application/vnd.ms-excel";
                    curContext.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=UTF-8>");
                    strWriter = new System.IO.StringWriter();
                    htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);
                    this.ClearControls(gvExportToExcel);
                    gvExportToExcel.RenderControl(htmlWriter);
                    curContext.Response.Write(strWriter.ToString());
                    curContext.Response.End();
    //Clear method.
    private void ClearControls(Control control)
        {
            try
            {
                for (int i = control.Controls.Count - 1; i >= 0; i--)
                {
                    ClearControls(control.Controls[i]);
                }
                if (!(control is TableCell))
                {
                    if (control.GetType().GetProperty("SelectedItem") != null)
                    {
                        LiteralControl literal = new LiteralControl();
                        control.Parent.Controls.Add(literal);
                        try
                        {
                            literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                        }
                        catch
                        {
                        }
                        control.Parent.Controls.Remove(control);
                    }
                    else
                        if (control.GetType().GetProperty("Text") != null)
                        {
                            LiteralControl literal = new LiteralControl();
                            control.Parent.Controls.Add(literal);
                            literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                            control.Parent.Controls.Remove(control);
                        }
                }
            }
            catch (Exception ee)
            {
                lblError.Visible = true;
                lblError.Text = ee.Message;
            }
            return;
        }
