    DataTemplate template = new DataTemplate();
    FrameworkElementFactory factory =
      new FrameworkElementFactory(typeof(StackPanel));
    template.VisualTree = factory;
    FrameworkElementFactory childFactory =
      new FrameworkElementFactory(typeof(Image));
    childFactory.SetBinding(Image.SourceProperty, new Binding("Machine.Thumbnail"));
    childFactory.SetValue(Image.WidthProperty, 170.0);    
    childFactory.SetValue(Image.HeightProperty, 170.0);
    factory.AppendChild(childFactory);
    childFactory = new FrameworkElementFactory(typeof(Label));
    childFactory.SetBinding(Label.ContentProperty,
      new Binding("Machine.Descriiption"));
    childFactory.SetValue(Label.WidthProperty, 170.0);
    childFactory.SetValue(Label.HorizontalAlignmentProperty,
      HorizontalAlignment.Center);
    factory.AppendChild(childFactory);
