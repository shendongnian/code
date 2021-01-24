    ContentControl cc = new ContentControl();
    cc.Content = new LongTextConverter();
    FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Image));
    frameworkElementFactory.SetBinding(Image.SourceProperty, new Binding("Image"));
    cc.ContentTemplate = new DataTemplate() { VisualTree = frameworkElementFactory };
    lvitem.Content = cc;
