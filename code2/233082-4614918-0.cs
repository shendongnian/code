    [DllImport("coredll.dll", SetLastError = true)]
    static extern bool SetSystemTime(ref SYSTEMTIME time);
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
        
        public SYSTEMTIME(DateTime value)
        {
            wYear = value.Year;
            wMonth = value.Month;
            wDayOfWeek = value.DayOfWeek;
            wDay = value.Day;
            wHour = value.Hour;
            wMinute = value.Minute;
            wSecond = value.Second;
            wMilliseconds = value.Milliseconds;
        }
    }
    public void setTimeButton_Click(object sender, EventArgs e)
    {
        // DateTimePicker usually provide with the date but not time information
        // so we need to get the current time
        TimeSpan currentSystemTime = DateTime.Now.TimeOfDay;
        DateTime newDate = newDateTimePicker.Value.Date;
        // Join the date and time parts
        DateTime newDateTime = newDate.Add(currentSystemTime);
    
        SYSTEMTIME newSystemTime = new SYSTEMTIME(newDateTime);
        if (!SetSystemTime(newSystemTime))
            Debug.WriteLine("Error setting system time.");
    }
