    data_grid.Resources.Add(
        typeof(Hyperlink),
        new Style(typeof(Hyperlink))
        .AddTrigger(
            new DataTrigger()
            {
                Binding = new Binding()
                {
                    Path = new PropertyPath("IsSelected"),
                    RelativeSource = new RelativeSource() { AncestorType = typeof(DataGridCell) }
                },
                Value = true
            }
            .AddSetter(new Setter(ForegroundProperty, new SolidColorBrush(Colors.White)))));
