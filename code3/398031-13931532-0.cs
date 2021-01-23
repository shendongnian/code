    for (int i = 0; i < SensorGridView.Rows.Count; i++)
    {
       DataGridViewRowHeaderCell cell = SensorGridView.Rows[i].HeaderCell;
       cell.Value = (i + 1).ToString();
          SensorGridView.Rows[i].HeaderCell = cell;
    }
