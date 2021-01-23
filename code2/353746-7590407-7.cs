    public MyObject()
    {    
       MyTimer = new System.Timers.Timer(100); // 10 Hz
       MyTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
       MyTimer.Enabled = true;
    }
    private void ImageDataUpdated(object sender, EventArgs e) 
    {
       // detach from the event to keep it from fireing until the timer event has fired.
       MyImageObject.Update -= new UpdateEventHandler(ImageDataUpdated);
        // do stuff
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // re-attach to the event handler.
       MyImageObject.Update += new UpdateEventHandler(ImageDataUpdated); 
    }
