    private void ExportReport()
    {
        // set the resulting file attachment name to the name of the report...
        string fileName = "test";
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        // Get the header row text form the sortable columns
        LinkButton headerLink = new LinkButton();
        string headerText = string.Empty;
        for (int k = 0; k < gvReport.HeaderRow.Cells.Count; k++)
        {
            //add separator
            headerLink = gvReport.HeaderRow.Cells[k].Controls[0] as LinkButton;
            headerText = headerLink.Text;
            sb.Append(headerText + ",");
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < gvReport.Rows.Count; i++)
        {
            for (int k = 0; k < gvReport.HeaderRow.Cells.Count; k++)
            {
                //add separator and strip "," values from returned content...
                sb.Append(gvReport.Rows[i].Cells[k].Text.Replace(",", "") + ",");
            }
            //append new line
            sb.Append("\r\n");
        }
        Response.Output.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
