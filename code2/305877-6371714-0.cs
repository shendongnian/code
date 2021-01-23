    foreach (DataRow rows in table.Rows)
    {
        object value = null;
        var cells = rows.ItemArray;
        for (int i = 0; i < cells.Length; i++)
        {
            value = cells[i];
            if (value != null && value.GetType() == typeof(int))
            {
                if ((int)value == 0)
                {
                    cells[i] = null;
                }
            }
        }
        rows.ItemArray = cells;
    }
