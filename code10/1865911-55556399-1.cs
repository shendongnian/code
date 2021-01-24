    var data_trigger = new DataTrigger()
    {
        Binding = new Binding()
        {
            Path = new PropertyPath("IsSelected"),
            RelativeSource = new RelativeSource() { AncestorType = typeof(DataGridCell) }
        },
        Value = true
    };
    
    data_trigger.Setters.Add(new Setter(ForegroundProperty, new SolidColorBrush(Colors.White)));
    
    var style = new Style(typeof(Hyperlink));
    
    style.Triggers.Add(data_trigger);
    
    data_grid.Resources.Add(typeof(Hyperlink), style);
