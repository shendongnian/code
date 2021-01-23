    Style style = new Style(typeof(System.Windows.Controls.Primitives
        .DataGridColumnHeader));
    style.Setters.Add(new Setter(ToolTipService.ToolTipProperty
        ,"Your tool tip here"));
    style.Setters.Add(new Setter { Property = BackgroundProperty, Value 
        = Brushes.Yellow });
    dgExcelSheet.Columns[1].HeaderStyle = style;
