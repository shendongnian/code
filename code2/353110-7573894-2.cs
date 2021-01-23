    public override void Update(GameTime gameTime)
        {
            float deltaTime = ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000f;
            currentState = Keyboard.GetState();
            if (canMove)
            {
                // Input
                if (currentState.IsKeyDown(Keys.Left))
                    Acceleration.X -= 1000;
                if (currentState.IsKeyDown(Keys.Right))
                    Acceleration.X += 1000;
                if (!airbourne && currentState.IsKeyDown(Keys.Space) && previousState.IsKeyUp(Keys.Space))
                {
                    Acceleration.Y -= 25000;
                    airbourne = true;
                }
                // Friction in X to limit sliding
                if (Velocity.X > 0)
                {
                    Velocity.X -= X_FRICTION;
                    if (Velocity.X < 0)
                        Velocity.X = 0;
                }
                else
                {
                    Velocity.X += X_FRICTION;
                    if (Velocity.X > 0)
                        Velocity.X = 0;
                }
                // Gravity
                Acceleration.Y += 500;
            }
            Velocity += Acceleration * deltaTime;
            if (Velocity.X > 0)
                Velocity.X += speedMod;
            else if (Velocity.X < 0)
                Velocity.X -= speedMod;
            // Move and check collisions in X
            Position.X += Velocity.X * deltaTime;
            if (game.checkCollisions(boundingBox()))
            {
                Position.X -= Velocity.X * deltaTime;
                Velocity.X = 0;
            }
            // Move and check collisions in Y
            Position.Y += Velocity.Y * deltaTime;
            movingUp = Velocity.Y < 0;
            if (game.checkCollisions(boundingBox()))
            {
                // If moving downwards, player not airbourne
                if (Velocity.Y >= 0)
                {
                    airbourne = false;
                    Position.Y = game.getCollisionDistance(boundingBox()) - 32;
                }
                else
                {
                    Position.Y = game.getCollisionDistance(boundingBox()) + 32;
                }
                Velocity.Y = 0;
            }
            else
                airbourne = true;
            movingUp = false;
            // Reset acceleration
            Acceleration = Vector2.Zero;
            previousState = currentState;
        }
