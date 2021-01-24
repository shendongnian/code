    foreach (DataGridViewCell cell in Olcu_Listesi.SelectedCells)
    {
        if (Olcu_Listesi[0, cell.RowIndex].Style.BackColor == Color.LightGreen)
            if (cell.ColumnIndex == 1 || cell.ColumnIndex == 2)
            {
                Olcu_Listesi[1, cell.RowIndex].Value = null;
                Olcu_Listesi[2, cell.RowIndex].Value = null;
                Olcu_Listesi[3, cell.RowIndex].Value = null;
                // Set back color to the first cell inside selected row
                Olcu_Listesi[0, cell.RowIndex].Style.BackColor = DefaultBackColor;
            }
    }
