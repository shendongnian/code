    private void dataGridView_CellFormatting(object sender,
               DataGridViewCellFormattingEventArgs e)
    {
          if (e.Value != null && e.Value != DBNull.Value)
                e.Value =  ((TimeSpan)e.Value).Hours.ToString("00") + ":" +
                           ((TimeSpan)e.Value).Minutes.ToString("00");
    }
    
