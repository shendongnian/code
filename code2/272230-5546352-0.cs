    for (int i = 0; i < 2800; i++)
    {
        Dispatcher.BeginInvoke(() => 
        {
            int index = LayoutRoot.Children.Count;
            Rectangle rect = new Rectangle()
            {
                Width = 10d,
                Height = 10d,
                Fill = new SolidColorBrush(Colors.Red),
            };
            int row = index / 4;
            int col = 10*(index % 70);
            Canvas.SetTop(rect, col);
            Canvas.SetLeft(rect, row);
            LayoutRoot.Children.Add(rect);
        });
        Thread.Sleep(1);                
    }
