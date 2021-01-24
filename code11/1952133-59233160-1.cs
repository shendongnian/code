    protected void Completed_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Completed.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = GetDatafromDatabase_Completed();
            string str = string.Empty;
    		Response.Write("<table border='1'>");
    		Response.Write("<tr>");
            foreach (DataColumn dtcol in dt.Columns)
            {
    			Response.Write("<td>");
                Response.Write(str + dtcol.ColumnName);
                Response.Write("</td>");
            }
            Response.Write("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
    			Response.Write("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
    				Response.Write("<td>");
    				String lineFeedToBreakConvertedData = Convert.ToString(dr[j]).Replace("\n", "<br>");
                    Response.Write(str + lineFeedToBreakConvertedData);
                    Response.Write("</td>");
                }
    			Response.Write("</tr>");
            }
    		Response.Write("</table>");
            Response.End();
        }
