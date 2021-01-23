    ScrollViewer scrollViewer = new ScrollViewer();
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            scrollViewer.Content = stackPanel;
            stackPanel.Children.Add(new TextBlock(){
                Text = "some text"
        });
            stackPanel.Children.Add(new TextBlock(){
                Text = "some text2"
        });
