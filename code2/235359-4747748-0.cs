    foreach (var instrument in instruments)
    {
        var column = new GridViewColumn
                            {
                                HeaderTemplate = GetColumnHeaderTemplate(instrument),
                                CellTemplate = GetColumnCellTemplate(instrument),
                                Header = instrument,
                            };
    
        view.Columns.Add(column);
    }
    private static DataTemplate GetColumnCellTemplate(string instrument)
    {
        var binding = new Binding
        {
            ConverterParameter = instrument,
            Converter = new InstrumentSelectionConverter(),
            Mode = BindingMode.OneWay
        };
    
        var template = new DataTemplate();
        template.VisualTree = new FrameworkElementFactory(typeof(CheckBox));
        template.VisualTree.SetBinding(ToggleButton.IsCheckedProperty, binding);
    
        return template;
    }
