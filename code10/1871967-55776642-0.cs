    foreach (DataGridViewRow row1 in table1.Rows) //LOOP ROWS TABLE 1
    {
        foreach (DataGridViewCell cell1 in row1.Cells) //LOOP COLUMNS TABLE 1
        {
            foreach (DataGridViewRow row2 in table2.Rows) //LOOP ROWS TABLE 2
            {
                foreach (DataGridViewCell cell2 in row2.Cells) //LOOP COLUMNS TABLE 2
                {
                    if (cell1.Value != null && cell2.Value != null&& cell2.Value.ToString() == cell1.Value.ToString())
                    {
                        cell1.Style.BackColor = Color.Yellow;
                        cell2.Style.BackColor = Color.YellowGreen;
                    }
                }
            }
        }
    }
