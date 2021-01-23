    private void myCanvas_Loaded(object sender, RoutedEventArgs e)
            {
                Line line = new Line();
                
                line.MouseDown += new MouseButtonEventHandler(line_MouseDown);
                line.MouseUp   += new MouseButtonEventHandler(line_MouseUp);
                
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 2;
                line.X1 = 30; line.X2 = 80;
                line.Y1 = 30; line.Y2 = 30;
    
                myCanvas.Children.Add(line);
            }
    
    void line_MouseUp(object sender, MouseButtonEventArgs e)
            {
                // Change line colour back to normal 
                ((Line)sender).Stroke = Brushes.Black;
            }
    
    void line_MouseDown(object sender, MouseButtonEventArgs e)
            {
                // Change line Colour to something
                ((Line)sender).Stroke = Brushes.Red;
            }
