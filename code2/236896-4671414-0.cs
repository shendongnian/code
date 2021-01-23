    private readonly Vector2 normalTop = new Vector2(0, 1);
    private readonly Vector2 normalBottom = new Vector2(0, -1);
    
    public void CheckBallPositionAndMove()
    {
        if (ball.Position.Y <= 0)
            ball.HandleCollision(normalTop);
        else if(ball.Position.Y >= graphics.PreferredBackBufferHeight)
            ball.HandleCollision(normalBottom);
    
        ball.Move();
        
        if (ball.Position.X < 0 || ball.Position.X >= graphics.PreferredBackBufferWidth)
            ball.Reset();
    }
    
    private void HandleCollision(Vector2 normal)
    {
        Direction = Vector2.Reflect(Direction, normal);
    }
    
    private void Move()
    {
        this.Position += Direction;
    }
