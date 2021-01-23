       protected void btnExportToExcel_Click(object s, EventArgs e)
        {
        
        GridView gvExportExcel = new GridView();
                            gvExportExcel.ID = "ExportExcel";
                            gvExportExcel.AllowPaging = false;
                            gvExportExcel.DataSource = listOfData(Generic list);
                            gvExportExcel.DataBind();
                            for (int i = 0; i < gvExportExcel.Rows.Count; i++)
         gvExportExcel.Rows[i].Cells[0].Attributes.Add("style", "mso-number-format:\\@");
                          
                            Export("Test.xls", gvExportExcel);
        }
    private void Export(string fileName, GridView dgvExport)
            {
                try
                {
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    Response.Charset = string.Empty;
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    dgvExport.RenderControl(htw);
    
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.Close();
                    //HttpContext.Current.Response.End();
    
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //write your exception
                }
    }
