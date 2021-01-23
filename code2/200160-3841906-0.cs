    private GridViewColumn GetGridViewColumn(string header, double width, string bindingProperty, Type type)
        {
            GridViewColumn column = new GridViewColumn();
            column.Header = header;
            
            FrameworkElementFactory controlFactory = new FrameworkElementFactory(type);
            var itemsBinding = new System.Windows.Data.Binding(bindingProperty);
            controlFactory.SetBinding(TextBox.TextProperty, itemsBinding);
            DataTemplate template = new DataTemplate();
            template.VisualTree = controlFactory;
            
            column.CellTemplate = template;
            return column;
        }
