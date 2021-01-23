    for (int i = 0; i < Game1.Ships.Count; i++)
    {
        if(Game1.Ships.ElementAt(i) is Enemy)
        {
            Enemy e = (Enemy)Game1.Ships.ElementAt(i);
            if (this.collisionBox.Intersects(e.collisionBox))
            {
                e.Destroy(false);
                //Execute Destory(bool).
            }
        }
        else
            i++;
            //Skip to next item.
    }
