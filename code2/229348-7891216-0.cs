    FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
    var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
                    var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
                    column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
    
    gridFactory.AppendChild(column1);
    gridFactory.AppendChild(column2);
 
