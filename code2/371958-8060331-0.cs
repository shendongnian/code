    StringBuilder html = new StringBuilder();
    foreach(DataTable aTable in tableList)
    {
       html.Append("<table>");
       foreach(DataRow row in aTable)
       {
          html.Append("<tr>");
          foreach(string cell in row.Items)
          {
             html.Append("<td>");
             html.Append(cell);
             html.Append("</td>");
          }
          html.Append("</tr>");
       }
       html.Append("</table>");
    }
