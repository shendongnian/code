    private DataTemplate GetDataTemplate()
        {
            var dataTemplate = new DataTemplate(typeof(MessageDto));
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            FrameworkElementFactory timestamp = new FrameworkElementFactory(typeof(Label));
            timestamp.SetBinding(Label.ContentProperty, new Binding("Timestamp"));
            FrameworkElementFactory from = new FrameworkElementFactory(typeof(Label));
            from.SetBinding(Label.ContentProperty, new Binding("From"));
            FrameworkElementFactory message = new FrameworkElementFactory(typeof(Label));
            message.SetBinding(Label.ContentProperty, new Binding("Message"));
            stackPanelFactory.AppendChild(timestamp);
            stackPanelFactory.AppendChild(from);
            stackPanelFactory.AppendChild(message);
            dataTemplate.VisualTree = stackPanelFactory;
            return dataTemplate;
        }
