    private bool ExitWait(bool bDelay)
    {
        if (m_bStopped)
            return true;
        if (bDelay)
        {
            DateTime now = DateTime.Now;
            DateTime later = DateTime.Now;
            TimeSpan difT = (later - now);
            while (difT.TotalMilliseconds < MainDef.IE_PARSER_DELAY)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(10);
                later = DateTime.Now;
                difT = later - now;
                if (m_bStopped)
                    return true;
            }
        }
        return m_bStopped;
    }
