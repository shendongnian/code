    Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Completed.xls"));
                Response.ContentType = "application/ms-excel";
                Response.Write("<table border='1'>");
                Response.Write("<tr>"); // Header row starts
                Response.Write("<td>Column 1</td> <td>Column2</td>");
                Response.Write("</tr>"); // header Row ends
                Response.Write("<tr>");  // First data row starts
                Response.Write("<td> Row1 Column1 Data 1</td>");
                Response.Write("<td> Row1 Column2 Data 1</td>");
                Response.Write("</tr>"); // First data row ends
    
                Response.Write("<tr>");  // Second data row starts
                Response.Write("<td> Row2 Column1 Data 1</td>");
                Response.Write("<td> Row2 Column2 Data 1");
                Response.Write("<br>"); // Makes it look like new line in same cell (Alt + Enter in excel)
                Response.Write("Row2 Column2 Data 2");
                Response.Write("<br>"); // Makes it look like new line in same cell (Alt + Enter in excel)
                Response.Write("Row2 Column2 Data 3</td>");
                Response.Write("</tr>"); // Second data row ends
    
                Response.Write("<tr>"); // Third data row Starts
                Response.Write("<td> Row3 Column1 Data 1</td>");
                Response.Write("<td> Row3 Column2 Data 1</td>");
                Response.Write("</tr>"); // Third data row Starts
                Response.Write("</table>");
                Response.End();
