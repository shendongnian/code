    StringBuilder html = new StringBuilder();
    foreach(DataTable aTable in tableList)
    {
       html.Append("<table>");
       foreach(DataRow row in aTable.rows)
       {
          html.Append("<tr>");
          foreach(string cell in row.Items)
          {
             html.Append("<td>");
             if (cell == null)
                html.Append("&nbsp;");
             else
                html.Append(cell);
             html.Append("</td>");
          }
          html.Append("</tr>");
       }
       html.Append("</table>");
    }
