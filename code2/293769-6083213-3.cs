    public struct SYSTEMTIME
    {    
      public ushort wYear,wMonth,wDayOfWeek,wDay,wHour,wMinute,wSecond,wMilliseconds;
    }
   
    [DllImport("kernel32.dll")]
    public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
    
    SYSTEMTIME systime = new SYSTEMTIME();
    systime = ... // Set the UTC time here
    SetSystemTime(ref systime);
