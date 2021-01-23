    private void myCanvas_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
    {
    
                Ellipse el = new Ellipse();
                el.Width = 10;
                el.Height = 10;
                el.Fill = new SolidColorBrush(Colors.Red);
                Canvas.SetLeft(el, e.ManipulationOrigin.X);
                Canvas.SetTop(el, e.ManipulationOrigin.Y);
                myCanvas.Children.Add(el);
    }
