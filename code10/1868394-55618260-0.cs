    Stopwatch stopwatch = new Stopwatch();
    int counter = 0;
    
    public void OnSensorChanged(SensorEvent e)
    {
        if (!stopwatch.IsRunning)
        {
            // start the stopwatch
            stopwatch.Start();
        }
        else
        {
            if (stopwatch.ElapsedMiliseconds <= 10)
            {
                counter++;
                return;
            }
        }
        Console.WriteLine(counter);
        // 10ms passed, restart the stopwatch
        stopwatch.Restart();
    }
