    aggregate Vector
    {
        int x, y, z;
        public void M(Action action)
        {
             Console.WriteLine(this.x);
             action();
             Console.WriteLine(this.x);
        }
    }
    ...
    Vector v = new Vector(1, 2, 3);
    Action action = ()=>{ v = new Vector(4, 5, 6); };
    v.M(action);
