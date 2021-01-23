    private static void TimerGo(object source, System.Timers.ElapsedEventArgs e)
    {
        tagList = reader.GetData(); // This is a collection of 10 objects.
        storeData(tagList); // This calls the 'storeData' method below
        timer.Start();
    } 
