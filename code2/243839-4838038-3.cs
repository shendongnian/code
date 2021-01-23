    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
    
        if (TouchPanel.IsGestureAvailable)
        {
            if (TouchPanel.ReadGesture().GestureType == GestureType.Tap)
            {
                Debug.WriteLine("A");
            }
        }
    
        // TODO: Add your update logic here
    
        base.Update(gameTime);
    }
