    [System.Flags]
    public enum ObjectList
    {
        Car = 1 << 0,
        Sword = 1 << 1,
        Friends = 1 << 2,
        Depression = 1 << 3 
    }
    
    [EnumFlag]
    public ObjectList hasItem;
