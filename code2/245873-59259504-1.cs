    private void DataGrid_PreparingCellForEdit(object sender, 
      DataGridPreparingCellForEditEventArgs e)
    {
      if (!(e.Column is DataGridTextColumn && e.EditingElement is TextBox textBox))
        return;
      var style = new Style(typeof(TextBox), textBox.Style);        
      style.Setters.Add(new Setter { Property = ForegroundProperty, Value = Brushes.Red });
      textBox.Style = style;      
    }
