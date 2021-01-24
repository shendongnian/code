    public static Mutex CreateMutex() {
     MutexAccessRule rule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
     MutexSecurity mutexSecurity = new MutexSecurity();
     mutexSecurity.AddAccessRule(rule);
     bool createdNew;
     return new Mutex( "Global\E475CED9-78C4-44FC-A2A2-45E515A2436", out createdNew, mutexSecurity, initiallyOwned: false,);
    }
