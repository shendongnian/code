    var myRectangle = new System.Windows.Shapes.Rectangle();
    
    mainGrid.Children.Add(myRectangle);
    myRectangle.Margin = new Thickness(50, 50, 0, 0);
    myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
    myRectangle.VerticalAlignment = VerticalAlignment.Top;
    
    myRectangle.Height = 100;
    myRectangle.Width = 100;
    myRectangle.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
