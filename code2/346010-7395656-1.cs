    class User
    {
        // all of these may be null if not applicable
        VendorRole VendorRole { get; set; }
        EmployeeRole EmployeeRole { get; set; }
        ICollection<AdvertiserRole> AdvertiserRoles { get; }
    }
