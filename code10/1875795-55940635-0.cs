    private DispatcherTimer IndividualTestStart(Button startButton, Button stopButton, 
        TimeSpan timeSpan, TextBox timeRemaining, TextBox cycleCount)
    {
        stopButton.IsEnabled = true; //Enables the stop button
        //Set the time to run. This will be set from the database eventually.
        timeSpan = TimeSpan.FromSeconds(10);
        //  Set up the new timer. Updated every second.
        var dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
        {
            timeRemaining.Text = timeSpan.ToString("c"); //Sets the text in the textbox to the time remaining in the timer
            startButton.IsEnabled = false; //Disables the start test button once the test is started
            if (timeSpan == TimeSpan.Zero) //Checks to seee if the time has run out
            {
                dispatcherTimer.Stop(); //Stops the timer once the time has run out
                startButton.IsEnabled = true; //Enables the start test button
                int initialCycleCount = 0;
                initialCycleCount++;
                cycleCount.Text = initialCycleCount.ToString();
                stopButton.IsEnabled = false;//Disables the stop button
            }
            timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1)); //Subtracts one second each time the timer "ticks"
        }, Application.Current.Dispatcher);  //runs within the UI thread
        dispatcherTimer.Start(); //Starts the timer 
        return dispatcherTimer;
    }
    public void motorOnBtn_1_Click(object sender, RoutedEventArgs e)
    {
        if (motorTimer_1 == null)
        {
            IndividualTestStart(motorOnBtn_1, motorOffBtn_1, motorCycleTime_1, 
                timeUntilmotorCycle_1, motorTestCycles_1);
        }
        else
        {
            //  It's already there, just start it. 
            motorTimer_1.Start();
        }
    }
