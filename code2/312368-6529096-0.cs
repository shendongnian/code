    public class GridViewExportUtil
    {
        /// <summary>Exports a Gridview to Excel</summary>
        /// <param name="fileName">File Name For The Excel file.</param>
        /// <param name="gv">Gridview to Export</param>
        public static void Export(string fileName, GridView gv)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            bool dataAdded = false;
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();
                    //Add Lines
                    table.GridLines = gv.GridLines;
                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                        
                        //Add Some Basic Formatting
                        foreach (TableCell tc in table.Rows[table.Rows.Count - 1].Cells)
                        {
                            tc.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
                            tc.BackColor = System.Drawing.Color.Black;
                            tc.ForeColor = System.Drawing.Color.White;
                        }
                    }
                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        GridViewExportUtil.PrepareControlForExport(row);
                        table.Rows.Add(row);
                        dataAdded = true;
                    }
                    //If no data added add row with the Gridviews' no data message
                    if (!dataAdded)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = gv.EmptyDataText;
                        cell.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
                        TableRow tmpRow = new TableRow();
                        tmpRow.Cells.Add(cell);
                        table.Rows.Add(tmpRow);
                    }
                    
                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }                    
                    //  render the table into the htmlwriter
                    table.RenderControl(htw);
                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }
        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }
                if (current.HasControls())
                {
                    GridViewExportUtil.PrepareControlForExport(current);
                }
            }
        }
    }
