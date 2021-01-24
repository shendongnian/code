            DataTable dt = GetData();
            StringBuilder sb = new StringBuilder();
            //Table start.
            sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");
            //Adding HeaderRow.
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr>");
            //Adding DataRow.
            foreach (DataRow row in dt.Rows)
            {
                if (row["Status"].ToString() == "Online")
                {
                    sb.Append("<tr style='background-color: #33cc33;'>");
                }
                else if (row["Status"].ToString() == "Offline")
                {
                    sb.Append("<tr style='background-color: #ff0000;'>");
                }
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            //Table end.
            sb.Append("</table>");
            mytable.Text = sb.ToString();
        }`
