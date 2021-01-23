    interface IActor
    {
        void LoadContent(ContentManager content);
        void UnloadContent();
        void Think(float seconds);
        void UpdatePhysics(float seconds);
        void Draw(SpriteBatch seconds);
        void Touched(IActor by);
        Vector2 Position { get; }
        Rectangle BoundingBox { get; }
    }
