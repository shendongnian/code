    private void Standard_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex >= 0)
         {
            int intHeaderId = 0;
            switch (((DataGridView)sender).Columns[e.ColumnIndex].Name)
            {
               case "grcHeaderId":
                  intHeaderId = (int)grvEnteredRecords[grcHeaderId.Index, e.RowIndex].Value;
                  break;
    ...
