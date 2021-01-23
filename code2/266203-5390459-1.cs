    Button btn = new Button();
            btn.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            btn.VerticalContentAlignment = VerticalAlignment.Stretch;
            StackPanel stk = new StackPanel();
            stk.Orientation = Orientation.Horizontal;
            stk.Margin = new Thickness(10, 10, 10, 10);
            stk.SetResourceReference(StackPanel.BackgroundProperty, "LeftMenuBackgroundImageBrush");
            btn.Content = stk;
