    public void CheckBallPositionAndMove()
    {
        if (ball.Position.Y <= 0 || ball.Position.Y >= graphics.PreferredBackBufferHeight)
            ball.HandleWallCollision();
    
        ball.Move();
        
        if (ball.Position.X < 0 || ball.Position.X >= graphics.PreferredBackBufferWidth)
            ball.Reset();
    }
    
    //In Ball.cs:
    private void HandleWallCollision(Vector2 normal)
    {
        Direction.Y *= -1; //Reflection about either normal is the same as multiplying y-vector by -1
    }
    
    private void Move()
    {
        this.Position += Direction;
    }
