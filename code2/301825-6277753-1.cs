    for (int i = 0; i < loop1counter; i++)
        {
            TableRow row = CopyTableRow(myTable.Rows[1]); //Duplicate original row
            char c = (char)(66 + i);
            if (c != 'M')
            {
                row.Cells[0].Text = c.ToString();
                myTable.Rows.Add(row);
            }
        }
