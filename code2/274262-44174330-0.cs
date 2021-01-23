       {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[8];//Means column 9
          
            if (statusCell.Text == "0")
            {
                statusCell.Text = "No Doc uploaded";
                 
            }
            else if (statusCell.Text == "1")
            {
                statusCell.Text = "Pending";
            }
            else if (statusCell.Text == "2")
            {
                statusCell.Text = "Verified";
            }
        }
    }
