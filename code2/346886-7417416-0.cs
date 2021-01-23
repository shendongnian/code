    public ActionResult Export(...) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='" + "2px" + "'b>");
            //write column headings
            sb.Append("<tr>");
            foreach (System.Data.DataColumn dc in dt.Columns) {
                sb.Append("<td><b><font face=Arial size=2>" + dc.ColumnName + "</font></b></td>");
            }
            sb.Append("</tr>");
            //write table data
            foreach (System.Data.DataRow dr in dt.Rows) {
                sb.Append("<tr>");
                foreach (System.Data.DataColumn dc in dt.Columns) {
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + dr[dc].ToString() + "</font></td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            this.Response.AddHeader("Content-Disposition", "Employees.xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
                return File(buffer, "application/vnd.ms-excel");
    }
