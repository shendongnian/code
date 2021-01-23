    List<Vector2> Movement = new List<Vector2>();    
    public override void Update(GameTime gameTime)
    {
        MouseState pms;
        MouseState ms = Mouse.GetState();
        
        pms = ms;
        Movement.Add(pms.X - ms.X, pms.Y - ms.Y);
        if(ms.LeftButton == ButtonState.Released){ Movement.Clear(); }
        base.Update(gameTime);
    }
