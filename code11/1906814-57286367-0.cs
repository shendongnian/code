    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TextBox textbox = new TextBox();
            textbox.Text = "Testing...";
            //cell1.Text = "<input type=\"text\"></input>";
            cell1.Controls.Add(textbox);
            row.Cells.Add(cell1);
            //proptable is the table id
            PropTable.Rows.Add(row);
        }
