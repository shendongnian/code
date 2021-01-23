    [DllImport("kernel32.dll")]
    private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
    
    private void SetTime()
    {
        // Call the native GetSystemTime method
        // with the defined structure.
        SYSTEMTIME systime = new SYSTEMTIME();
        GetSystemTime(ref systime);
    
        // Set the system clock ahead one hour.
        systime.wHour = (ushort)(systime.wHour + 1 % 24);
        SetSystemTime(ref systime);
        MessageBox.Show("New time: " + systime.wHour.ToString() + ":"
            + systime.wMinute.ToString());
    }
