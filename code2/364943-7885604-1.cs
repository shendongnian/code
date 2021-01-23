        var window = new Window();
        var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
        stackPanel.Children.Add(new Label { Content = "Label" });
        stackPanel.Children.Add(new Button { Content = "Button" });
        window.Content = stackPanel;
