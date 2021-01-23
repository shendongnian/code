    enum PositionType
    {
        Head,
        Chest,
        Hand,
        Feet,
        Finger,
        Neck
    }
    public interface IClothing
    {
        PositionType Type { get; }
        // Other things you need IClothing-classed to implement
    }
