        if (!Jumping && FaKeyboard.IsKeyDown(Keys.Space))
        {
            Jumping = true;
            Grounded = false;
        }
        if (Jumping)
        {
            xPosition -= new Vector2(0, 5);
        } 
        if (xPosition.Y >= 10)
        {
            Jumping = false;
        }
