    if (keyboardState.IsKeyDown(Keys.Right))
    {
        foreach( var pos in GlobalClass.BlocksPositions.Reverse() )
        {
            var rect = new Rectangle((int)pos.X, (int)pos.Y, bT.Width, bT.Height);
            var rectToTest = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            if (!rect.IntersectsWith(rectToTest))
                Position.X += Speed;
            else
                break;
        }
    }
