        if (ballRect.Intersects(bat1Rect))
        {
            ballVelo.X = Math.Abs(ballVelo.X) * -1;
        }
        if (ballRect.Intersects(bat2Rect))
        {
            ballVelo.X = Math.Abs(ballVelo.X);
        }
