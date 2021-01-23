    class Sphere {
        public Vector3 Pos;
        public double Radius;
    }
    void Test() 
    {
        Sphere big = new Sphere() { Pos = new Vector3(0, 0, 0), Radius = 10.0 };
        Sphere small = new Sphere() { Pos = new Vector3(8, 0, 0), Radius = 1.0 };
        Vector3 move = new Vector3(0, 10, 0);
        
        // new position without check, if within sphere ok
        Vector3 newPos = small.Pos + move;
        if (Vector3.Distance(newPos, big.Pos) < big.Radius - small.Radius)
            return;
        // diff in radius to contact with outer shell
        double space = (big.Radius - small.Radius) - Vector3.Distance(small.Pos, big.Pos);
        
        // movement past moment of hitting outer shell
        double far = Vector3.Distance(newPos, big.Pos) - (big.Radius - small.Radius);
        // scale movement by ratio to get movement to hit shell
        move = move * (space / (space + far));
        newPos = small.Pos + move;
    }
    
