    SpriteEffects s = SpriteEffects.FlipHorizontally;
    int smX = 200; //smx is the 'x' coordinates.
        
        public void runChar()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                smX -= 2;
                s = SpriteEffects.FlipHorizontally;
                //oposite direction.
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                smX += 2;
                s = SpriteEffects.None;
                //original direction.
            }
        }
    spriteBatch.Draw(sM, new Rectangle(smX, 200, 100, 100), null, Color.White, rotation, new Vector2(50, 50), s, 0f);
