    private void UltraGridEdit_AfterCellUpdate(object sender, CellEventArgs e)
    {
      if(e.Cell.Column.Key == "Amount_Column_Key")
      {
        e.Cell.Row.Cells["StartDate"].Value = CalculateStartDateValue();
      }
    }
    private DateTime CalculateStartDateValue()
    {
      // calculate start date value here
    }
