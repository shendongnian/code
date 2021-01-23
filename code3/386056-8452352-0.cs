    [Flags]
    enum PositionType
    {
        Head,
        Chest,
        Hand,
        Feet,
        Finger,
        Neck
    }
    Armor robe = new Armor(); //sure why not.
    robe.ArmorValue = 125.3;
    robe.Appeal = 100;    
    robe.PositionType = PositionType.Chest | PositionType.Arms | PositionType.BellyButton; 
