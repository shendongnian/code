    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // if a subscriber exists
        if (HasSubscriber)
        {
           // Notify Subscriber
           Subscriber.Refresh();
        }
    }
