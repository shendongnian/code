    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += dispatcherTimer_Tick;
    dispatcherTimer.Interval = new TimeSpan(0,0,1);
    dispatcherTimer.Start();
    
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        Random rnd = new Random();
        int movex = rnd.Next(0, 2);
        int movey = rnd.Next(0, 2);
        Canvas.SetTop(image1, Canvas.GetTop(image1) + (movey == 1 ? 1 : -1));
        Canvas.SetLeft(image1, Canvas.GetLeft(image1) + (movex == 1 ? 1 : -1));
    }
