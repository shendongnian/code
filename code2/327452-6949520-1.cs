    static string GetCharsFromKeys(Keys keys, bool shift, bool altGr)
    {
        var buf = new StringBuilder(256);
        var keyboardState = new byte[256];
        if (shift)
            keyboardState[(int) Keys.ShiftKey] = 0xff;
        if (altGr)
        {
            keyboardState[(int) Keys.ControlKey] = 0xff;
            keyboardState[(int) Keys.Menu] = 0xff;
        }
        WinAPI.ToUnicode((uint) Keys.E, 0, keyboardState, buf, 256, 0);
        return buf.ToString();
    }
