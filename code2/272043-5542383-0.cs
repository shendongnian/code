    public static void SetTimeZoneInformation( TimeZoneInformation tzi )
    {
        // Call CE function (implicit conversion occurs to
        // byte[]).
        if (!NativeMethods.SetTimeZoneInformation(tzi))
        {
            throw new System.ComponentModel.Win32Exception(
                Marshal.GetLastWin32Error(), "Cannot Set Time Zone");
        }
    }
