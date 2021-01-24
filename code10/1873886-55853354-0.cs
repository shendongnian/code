    foreach (DataGridViewRow row_dt1 in dt1.SelectedRows)
    {
        if (!row.IsNewRow)
        {
            // Find parent name of actual row
            string parent_name = row_dt1.Cells[0].Value.ToString();
            // Iteration over all rows of children
            for(int x = dt2.Rows.Count - 1; x >= 0; x--)
            {
                // Find child name
                DataGridViewRow row_dt2 = dt2.Rows[x];
                object val1 = row_dt2.Cells[0].Value;
                // If child name starts with parent name, remove this child from the DataGridView (dt2)
                if (val1 != null && val1.ToString().StartsWith(parent_name + "-"))
                {
                    dt2.Rows.Remove(row_dt2);
                }
            }
            // Now remove the parent from dt1
            dt1.Rows.Remove(row_dt1);
        }
    }
