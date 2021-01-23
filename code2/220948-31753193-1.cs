    public enum SqlNotificationSource {
        Data        = 0,
        Timeout     = 1,
        Object      = 2,
        Database    = 3,
        System      = 4,
        Statement   = 5,
        Environment = 6,
        Execution   = 7,
        Owner       = 8,
     
        // use negative values for client-only-generated values
        Unknown     = -1,
        Client      = -2
    }
