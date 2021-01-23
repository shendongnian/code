    private void dgResults_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
          if (e.PropertyType == typeof(byte[])) {
            e.Column.Header = e.Column.Header + "_D";
            // Create a new template column.
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
            templateColumn.Header = e.Column.Header + "_E";
            templateColumn.CellTemplate = (DataTemplate)Resources["imgTemplate"];
            templateColumn.CellEditingTemplate = (DataTemplate)Resources["imgTemplate"];
            // ...
            // Replace the auto-generated column with the templateColumn.
            e.Column = templateColumn;
    
          }
        }
