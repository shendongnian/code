    [Flags]
    enum Permission
    {
        None = 0x00,
        Read = 0x01,
        Write = 0x02,
    }
    ...
    Permission p = Permission.Read | Permission.Write;
