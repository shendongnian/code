    private void button1_Click(object sender, RoutedEventArgs e)
        {
            DockPanel dp = new DockPanel();
            Button btn = new Button();
            btn.Content = "Hello1";
            //Add the button to the DockPanel
            dp.Children.Add(btn);
            btn = new Button();
            btn.Content = "Hello2";
            //Add the button to the DockPanel
            dp.Children.Add(btn);
            //Add the DockPanel to the StackPanel
            stackPanel1.Children.Add(dp);
        }
