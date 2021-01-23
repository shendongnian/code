    TimedGate m_UpdateGate = new TimedGate(TimeSpan.FromMilliseconds(100));
    private void Update()
    {
        if (m_UpdateGate.TryEnter())
        {
            Console.WriteLine("!update");
            // do work here
        }
        else
        {
            Console.WriteLine("!skip update");
        }
    }
