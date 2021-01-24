    var Collide = MoveAndCollide(new Vector2(speed.y * (float)Math.Cos(teta), speed.y * (float)Math.Sin(teta)));
    if (Collide != null)
    {
        print(Collide.Collider.Name)
    }
 
