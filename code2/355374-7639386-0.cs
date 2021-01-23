    bool _allowProcessing = false;
    //SelectAll / Deselect All
    for (int i = 0; i < dgv.RowCount; i++)
    {
       dgv.Rows[i].Cells[4].Value = _selectAll;
    }
    _allowProcessing = true;
    // Do some processing if required
    
    // Checked change event
    public void CheckBox_CheckedChange(object sender, eventArgs e)
    {
      if(!_allowProcessing)
        return;
    
      // Do Processing
    }
