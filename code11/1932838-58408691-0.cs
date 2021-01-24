    private void Form1_Load(object sender, EventArgs e)
    {
        timer = new System.Timers.Timer();
        timer.Interval = 1000 * 60 * 5; // 1000ms = 1 second * 60 = 1 minute * 5 ...
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (DateTime.Now.TimeOfDay >= new TimeSpan(9, 30, 0) 
            && 
            DateTime.Now.TimeOfDay <= new TimeSpan(16, 0, 0))
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Windows\Media\Time interval alarm\FiveH.wav";
            player.Play();
        }
    }
