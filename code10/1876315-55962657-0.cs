    ControlTemplate template = new ControlTemplate(typeof(Button));
    FrameworkElementFactory elemFactory = new FrameworkElementFactory(typeof(Border));
    elemFactory.Name = "Border";
    elemFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
    template.VisualTree = elemFactory;
    elemFactory.AppendChild(new FrameworkElementFactory(typeof(ContentPresenter)));
    
