    [DllImport("BthUtil.dll")]
    private static extern int BthSetMode(RadioMode dwMode );
    [DllImport("BthUtil.dll")]
    private static extern int BthGetMode(ref RadioMode dwMode );
    /// Bluetooth states.
    public enum RadioMode
    {
       /// Bluetooth off.
       Off,
       /// Bluetooth is on but not discoverable.
       On,
       /// Bluetooth is on and discoverable.
       Discoverable,
    }
