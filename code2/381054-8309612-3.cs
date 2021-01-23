    [Flags]
    public enum Edges
    {
        None = 0,
        Top = 1,
        Bottom = 2,
        Left = 4,
        Right = 8,
        Identical = Top + Bottom + Left + Right,
        Inside = 16,
        Covers = 32
    }
