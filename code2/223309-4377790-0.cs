      switch (e.KeyData)
      {
        case Keys.F6: //Copy the row above.
          if (MyGridView.NewRowIndex > 0 && MyGridView.NewRowIndex == rowIndex)
          {
            int colIndex = MyGridView.CurrentCell.ColumnIndex;
    
            MyGridView.Rows.Add();
            MyGridView.CurrentCell = MyGridView.Rows[rowIndex].Cells[colIndex];
    
            MyGridView.CurrentRow.Cells[CustomColumn.Index].Value
              = MyGridView.Rows[rowIndex - 1].Cells[Customer.Index].Value;
    
            MyGridView.CurrentRow.Cells[DateColumn.Index].Value
              = MyGridView.Rows[rowIndex - 1].Cells[DateColumn.Index].Value;
    
            MyGridView.CurrentRow.Cells[RefColumn.Index].Value
              = MyGridView.Rows[rowIndex - 1].Cells[RefColumn.Index].Value;
           }
      }
