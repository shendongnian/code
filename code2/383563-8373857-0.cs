    void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
          if (e.ColumnIndex == 0) //Index of your DataGridViewComboBoxColumn 
          {
              e.Value = "Default Value";
          }
    }
