    if(((bool)dataGridView1.Rows[i].Cells[0]) == true)
    {
        // Loop through and get the values
        foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
        {
            data = data + (cell.Value + ",");
        }
        data += "\n";
    }
    else
    {
        // else block not really necessary in this case, but illustrates the point....
        continue;
    }
