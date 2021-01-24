        var Collide = MoveAndCollide(new Vector2(speed.y * (float)Math.Cos(teta), speed.y * (float)Math.Sin(teta)));
        //Just defined a MoveAndCollide
        if (Collide != null)
        {
            var x = (Godot.Node2D)Collide.Collider;
            //Use collider as a Godot Node or Node2D
            //then you can access Node properties and method like GetName()
            GD.PrintS(x.GetName()); // Returned speedBoost for me
        }
