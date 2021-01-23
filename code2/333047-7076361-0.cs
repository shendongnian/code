    private void AddTbToStackPanel(string text)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                StackPanel stackPanel = stackPanel1 as StackPanel;
                TextBlock tb = new TextBlock();
                tb.Text = text;                
                stackPanel.Children.Add(tb);
            }));
        }
