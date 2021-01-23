     using System.Web.UI.WebControls;
     foreach (DataRow row in dt.Rows)
     {
        var tableRow = new TableRow();
        foreach (DataColumn col in dt.Columns)
        {
           var tableCell = new TableCell();
           tableCell.Text = row[col];
           tableRow.Cells.Add(tableCell);
        }
        table.Rows.Add(tableRow);
     }
