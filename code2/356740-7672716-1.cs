    var users = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
    var security = new MutexSecurity();
    security.AddAccessRule(new MutexAccessRule(users, MutexRights.Synchronize, AccessControlType.Allow));
    security.AddAccessRule(new MutexAccessRule(users, MutexRights.Modify, AccessControlType.Allow));
    new Mutex(false, name, out createdNew, security);
