        public Vector2 GetPlayerMovement()
        {
            Vector2 r = Vector2.Zero;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(MOVEUP))
                r.Y -= 1;
            if (ks.IsKeyDown(MOVEDOWN))
                r.Y += 1;
            if (ks.IsKeyDown(MOVELEFT))
                r.X -= 1;
            if (ks.IsKeyDown(MOVERIGHT))
                r.X += 1;
            return r;
        }
