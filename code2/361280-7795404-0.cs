            // Define grid with columns and rows
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(113, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(55, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(13)});
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(24) });
            // Create each control and set its location
            var button = new Button { Name = "ButtonName", Content = "Button Content" };
            grid.Children.Add(button);
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 0);
            var textBox = new TextBox { Name= "TextBoxName"};
            grid.Children.Add(textBox);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(textBox, 0);
            // Create the tab control and add items
            var tabItem = new TabItem {Header = "Sample Header", Name = "TabName", Content = grid};
            var tabControl = new TabControl();
            tabControl.Items.Add(tabItem);
            MyWindow.AddChild(tabControl);
