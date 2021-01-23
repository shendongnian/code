    protected void CreatePositionTimer(TimeSpan interval)
    {
        if (m_timer == null)
        {
            m_timer = new DispatcherTimer();
            m_timer.Interval = interval; // 6 NTSC frames
            m_timer.Tick += new EventHandler(OnTimerTick);
        }
    }
