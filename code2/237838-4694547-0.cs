            if (tileCollision.X != -1 || tileCollision.Y != -1)
            {
                onGround = true;
                Vector2 collisionDepth = CollisionRectangle.DepthIntersection(
                    new Rectangle(
                        tileCollision.X * World.tileEngine.TileWidth,
                        tileCollision.Y * World.tileEngine.TileHeight,
                        World.tileEngine.TileWidth,
                        World.tileEngine.TileHeight
                    )
                );
                Velocity.Y = 0;
                // Depending on your coordinate system this should
                // be either + or - collisionDepth.Y
                Position.Y += collisionDepth.Y;
            }
