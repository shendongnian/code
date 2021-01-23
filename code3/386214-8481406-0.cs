    var myRectangle = new System.Windows.Shapes.Rectangle();
    
    var mainCanvas = new Canvas();
    mainGrid.Children.Add(mainCanvas);
    
    mainCanvas.Children.Add(myRectangle);
    Canvas.SetLeft(myRectangle, 50);
    Canvas.SetTop(myRectangle, 50);
    
    myRectangle.Height = 100;
    myRectangle.Width = 100;
    myRectangle.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
