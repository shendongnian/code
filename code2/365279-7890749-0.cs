    [Flags]
    public enum Materials
    {
       None = 0,
       Wood = 1,
       Stone = 1 << 1,
       Earth = 1 << 2,
       Water = 1 << 3,
       Lava = 1 << 4,
       Air = 1 << 5,
       Walkable = Wood | Earth | Stone
    }
    MyMat material = ..
    bool isWalkable = (material & isWalkable) != Materials.None;
