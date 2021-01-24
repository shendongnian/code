    struct State
    {
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        public State(Vector2 position, Vector2 velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
        }
