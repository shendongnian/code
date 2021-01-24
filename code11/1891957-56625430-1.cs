    private Timer timer;
    // just in case you want to keep track of needed times per lap
    public List<string> lapTimes = new List<string>();
    private void Awake()
    {
        timer = new Timer();
        lapTimes.Clear();
    }
    private void Update()
    {
        ...
        if(Lap < Pilot.pilotlap )
        {
            timer.Start(true);
            Lap++
        }
        else if(Lap == Pilot.pilotlap)
        {
            var currentTime = timer.GetCurrentTime();
            timerLabel.text = currentTime;
            lapTimes.Add(currentTime);
            timer.Start(true)
        }
        ...
    }
