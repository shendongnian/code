    private void DataGrid_PreparingCellForEdit(object sender, 
      DataGridPreparingCellForEditEventArgs e)
    {
      if (!(e.Column is DataGridTextColumn && e.EditingElement is TextBox textBox))
        return;
      var tbType = typeof(TextBox);
      var resourcesStyle = Application
        .Current
        .Resources
        .Cast<DictionaryEntry>()
        .Where(de => de.Value is Style && de.Key is Type styleType && styleType == tbType)
        .Select(de => (Style)de.Value)
        .FirstOrDefault();
      var style = new Style(typeof(TextBox), resourcesStyle);
      foreach (var setter in textBox.Style.Setters)
        style.Setters.Add(setter);
      textBox.Style = style;
    }
