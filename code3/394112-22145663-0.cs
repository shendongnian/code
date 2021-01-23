        using System;
        using System.Data;
        using System.Configuration;
        using System.IO;
        using System.Web;
        using System.Web.Security;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Web.UI.WebControls.WebParts;
        using System.Web.UI.HtmlControls;
        /// <summary>
        /// Summary description for GridViewExportUtil
        /// </summary>
        public class GridViewExportUtil
        {
	public GridViewExportUtil()
	{
		//
		// TODO: Add constructor logic here
		//
    }
        public static void ExportGridView(string fileName, GridView gv, Label header, Label date)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        gv.AllowPaging = false;
                        //  Create a table to contain the grid
                        Table table = new Table();
                        //  include the gridline settings
                        table.GridLines = gv.GridLines;
                        gv.Style["font-family"] = "Tahoma";
                        //  add the header row to the table
                        if (gv.HeaderRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                            gv.HeaderRow.BackColor = System.Drawing.Color.Lavender;
                            gv.HeaderRow.ForeColor = System.Drawing.Color.Green;
                            table.Rows.Add(gv.HeaderRow);
                        }
                        //  add each of the data rows to the table
                        foreach (GridViewRow row in gv.Rows)
                        {
                            GridViewExportUtil.PrepareControlForExport(row);
                            table.Rows.Add(row);
                        }
                        //  add the footer row to the table
                        if (gv.FooterRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                            table.Rows.Add(gv.FooterRow);
                        }
                        htw.WriteLine("<br>");
                        // htw.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                        if (header.Text != null)
                        {
                            header.Font.Size = 15;
                            header.Font.Bold = true;
                            header.ForeColor = System.Drawing.Color.Blue;
                            header.RenderControl(htw);
                        }
                        htw.WriteLine("</p>");
                        //  render the table into the htmlwriter
                        table.RenderControl(htw);
                        htw.WriteLine("<br>");
                        htw.WriteLine("Report taken on :", System.Drawing.FontStyle.Bold);
                        if (date.Text != null)
                        {
                            date.ForeColor = System.Drawing.Color.Blue;
                            date.RenderControl(htw);
                        }
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
                    else if (current is Label)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
                    }
            
                    if (current.HasControls())
                    {
                        GridViewExportUtil.PrepareControlForExport(current);
                    }
                }
            }
        }
