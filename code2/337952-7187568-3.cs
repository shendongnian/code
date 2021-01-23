    foreach (DataGridViewRow row in choiceDGV.SelectedRows)
    {
         object[] items = new object [row.Cells.Count];
         for (int i = 0; i < row.Cells.Count; i++)
             items[i] = row.Cells[i].Value;
         universalDGV.Rows.Add(items);
         choiceDGV.Rows.Delete(row);
    }
