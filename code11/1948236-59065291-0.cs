    protected void ExportToPDF(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=UserExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridView gv = GridView1;
    gv.Columns.RemoveAt(4);
    gv.Columns.RemoveAt(3);
            //To Export all pages
            gv.AllowPaging = false;
            this.BindGrid();
            gv.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gv.HeaderRow.Cells)
            {
                cell.BackColor = gv.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gv.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gv.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gv.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gv.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
