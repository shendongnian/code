    var mask = (AccessRights)25;
    var rightsForMask = Enum.GetValues(typeof(AccessRights))
                            .Cast<AccessRights>()
                            .Where(x => mask.HasFlag(x));
    foreach (var right in rightsForMask)
    {
        // displays "1:Read", "8:Delete", "16:Publish"
        Console.WriteLine((int)right + ":" + right);
    }
    // ...
    [Flags]
    public enum AccessRights
    {
        Read = 1, Create = 2, Edit = 4, Delete = 8, Publish = 16, Administer = 32
    }
