    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName != "Identifiant" && e.PropertyName != "=>")
        {
            FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
            image.SetBinding(Image.SourceProperty, new Binding(e.PropertyName));
            e.Column = new DataGridTemplateColumn
            {
                CellTemplate = new DataTemplate() { VisualTree = image }
                Header = e.PropertyName
            };
        }
    }
