    for (int i = 0; i < 10; i++)
    {
      Ellipse e = new Ellipse
        {
          Width = 100,
          Height = 100,
          Fill = new SolidColorBrush(
                   Color.FromArgb(0xDD, 
                        (Byte) r.Next(255)
                        (Byte) r.Next(255)
                        (Byte) r.Next(255))),
          Stroke = Brushes.Black,
          StrokeThickness = 1,
        };
      e.MouseUp += new MouseButtonEventHandler(e_MouseUp);
      Canvas.SetLeft(e, r.Next(400));
      Canvas.SetTop(e, r.Next(400));
      RootLayer.Children.Add(e);
    }
