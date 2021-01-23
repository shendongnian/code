    protected override void Update(GameTime gameTime)
    {
        Vector2 sMove = new Vector2(Position.X - DrawPosition.X, Position.Y - DrawPosition.Y);
        sMove.Normalize();
        // START CHANGE
        sMove = Vector2.Multiply(sMove, Math.Min(Vector2.Distance(DrawPosition, Position), Speed * gameTime.ElapsedGameTime.TotalSeconds));
        // END CHANGE
        DrawPosition.X += sMove.X;
        DrawPosition.Y += sMove.Y;
    }
