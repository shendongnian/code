    // assume the SafeQueue class from the cited doc page. 
    SafeQueue<SpecialHardware> q = new SafeQueue<SpecialHardware>()
    // set up the queue with objects protecting the 5 magic stones
    private void Setup() 
    {
        for (int i=0; i< 5; i++) 
        {
           q.Enqueue(GetInstanceOfSpecialHardware(i));
        }
    }
    // something like this gets called many times, by QueueUserWorkItem()
    public void DoWork(WorkDescription d)
    {
        d.DoPrepWork();
        // gain access to one of the special hardware devices
        SpecialHardware shw = q.Dequeue();
        try 
        {
            shw.DoTheMagicThing();
        }
        finally 
        {
            // ensure no matter what happens the HW device is released
            q.Enqueue(shw);
            // at this point another worker can use it.
        }
        d.DoFollowupWork(); 
    }
