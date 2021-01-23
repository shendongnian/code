    [Flags]
    public enum DriversLicenseFlagsInternal
    {
        None = 0,
        Suspended = 1 << 1,
        Revoked   = 1 << 2,
        Restored  = 1 << 3,
        SuspendedAndRestored = Suspended | Restored,
        RevokedAndRestored   = Revoked   | Restored,
    }
    
    [Flags]
    internal enum DriversLicenseFlags
    {
        None = DriversLicenseFlagsInternal.None,
        Suspended = DriversLicenseFlagsInternal.Suspended,
        Revoked   = DriversLicenseFlagsInternal.Revoked,
        SuspendedAndRestored = DriversLicenseFlagsInternal.SuspendedAndRestored,
        RevokedAndRestored   = DriversLicenseFlagsInternal.RevokedAndRestored,
    }
    public void DoSomething(DriversLicenseFlags arg)
    {
        var argAsInternal = (DriversLicenseFlagsInternal) arg;
    // or var argAsInternal = Util.CheckDefinedDriversLicense(arg);
    }
