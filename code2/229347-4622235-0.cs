    //create grid 
                var grid = new FrameworkElementFactory(typeof(Grid));
    
                // assign template to grid 
                CellControlTemplate.VisualTree = grid;
    
                // define grid's rows 
                var r = new FrameworkElementFactory(typeof(RowDefinition));
                grid.AppendChild(r);
    
                // define grid's columns
                var c = new FrameworkElementFactory(typeof(ColumnDefinition));
                grid.AppendChild(c);
    
                c = new FrameworkElementFactory(typeof(ColumnDefinition));
                c.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);
                grid.AppendChild(c);
    
                c = new FrameworkElementFactory(typeof(ColumnDefinition));
                c.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);
                grid.AppendChild(c);
