    private void Polyline_MouseDown(object sender, MouseButtonEventArgs e)
    {
        double left = Canvas.GetLeft(myPolyline);
        var animationThread = new Thread(new ThreadStart(() =>
        {
            while (left < 300)
            {
                left += 10;
                // SetLeft is done in the UI thread
                Dispatcher.Invoke(new Action(() =>
                {
                    Canvas.SetLeft(myPolyline, left);
                }));
                Thread.Sleep(50);
            }
        }));
        animationThread.Start();
    }
