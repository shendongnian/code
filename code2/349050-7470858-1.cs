        static int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf( lastInputInfo );
            lastInputInfo.dwTime = 0;
    
            int envTicks = Environment.TickCount;
    
            if ( GetLastInputInfo( ref lastInputInfo ) )
            {
            int lastInputTick = lastInputInfo.dwTime;
    
            idleTime = envTicks - lastInputTick;
            }
    
            return (( idleTime > 0 ) ? ( idleTime / 1000 ) : 0);
        }
