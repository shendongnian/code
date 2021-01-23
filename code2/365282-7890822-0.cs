    public enum Materials
    {
        [Walkable(true)]
        Wood,
        [Walkable(true)]
        Stone,
        [Walkable(true)]
        Earth,
        [Walkable(false)]
        Water,
        [Walkable(false)]
        Lava,
        [Walkable(false)]
        Air
    }
    public class WalkableAttribute : Attribute
    {
        public WalkableAttribute(bool value)
        {
            IsWalkable = value;
        }
        public bool IsWalkable { get; private set; }
    }
