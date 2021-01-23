    class Ship
    {
        public abstract bool IsPlayer { get; }
    }
    class Player : Ship
    {
        public override bool IsPlayer { get { return true; } }
    }
    class Enemy : Ship
    {
        public override bool IsPlayer { get { return false; } }
    }
