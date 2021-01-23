    my_rect.SetBinding(Rectangle.OpacityProperty, "state_opacity");
    my_rect.SetBinding(Rectangle.FillProperty,
                         new Binding()
                         {
                             Converter = new BooleanToBrushConverter(),
                             Path = new PropertyPath("state_color")
                         }
                      );
