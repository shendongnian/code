     if (Vector2.Distance(Position, TargetPosition) > 2.0f)
     {
        velocity = Vector2.Subtract(TargetPosition, Position);
        velocity.Normalize();
        /// Now no matter which direction we are going we are always moving @ sprite.Speed
        /// at velocity or speed below 1 - problems occur where the unit may not move at all!!
        if(current_Speed < 1)
        {
           Vector2 temp = (velocity * 10) * (current_Speed * 10);
           Position += temp / 10;
        }
        else
        { 
           Vector2 temp = velocity * current_Speed;
           Position += temp;
        }
        //convert to int to render sprite to pixel perfect..
        Position = new Vector2((int)Position.X, (int)Position.Y);
     }
