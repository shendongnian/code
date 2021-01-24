    [Flags]
    public enum Elements
    {
        none = 0b0000_0000_0000,
        fire = 0b0000_0000_0001,
        water = 0b0000_0000_0010,
        earth = 0b0000_0000_0100
    };
    public void ElementCollisionExample(Elements element1, Elements element2)
    {
        switch (element1 | element2)
        {
            case Elements.fire | Elements.water:
    
                Console.WriteLine("The fire is extinguished");
                break;
            case Elements.earth | Elements.fire:
    
                Console.WriteLine("The earth goes black");
                break;
        }
    }
