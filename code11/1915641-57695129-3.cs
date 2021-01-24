    enum Permission
    {
        NOTES = 1,
        LOGS = 2,
        SUPERUSER = 3
    };
    class PermissionValue
    {
        public Permission Permission { get; set; }
        public bool IsActive { get; set; }
    }
