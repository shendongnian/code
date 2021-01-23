    for (int i = 0; i < Game1.Ships.Count; i++)
    {
        var e = Game1.Ships[i] as Enemy;
        if (e != null)
            if (this.collisionBox.Intersects(e.collisionBox))
                e.Destroy(false);
    }
