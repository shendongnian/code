    for (int i = 0; i <= dgFilter.Rows.Count - 1; i++)
    {
        var cell = dgFilter.Rows[i].Cells[1] as DataGridViewComboboxCell;
        int index = cell == null || cell.Value == null ? -1 : cell.Items.IndexOf(cell.Value);
        Console.WriteLine(index);
    }
