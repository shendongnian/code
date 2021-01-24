public static Orientations AngleToVectorDirection(Transform transform)
    {
        float angle = GetMousePosition(transform);
        if(angle >= 67.5 && angle < 112.5)
        {
            return Orientations.N;
        }
        else if (angle >= 112.5 && angle < 157.5)
        {
            return Orientations.NW;
        }
        else if (angle >= 157.5 && angle < 202.5)
        {
            return Orientations.W;
        }
        else if (angle >= 202.5 && angle < 247.5)
        {
            return Orientations.SW;
        }
        else if (angle >= 247.5 && angle < 292.5)
        {
            return Orientations.S;
        }
        else if (angle >= 292.5 && angle < 337.5)
        {
            return Orientations.SE;
        }
        else if (angle >= 337.5 || angle < 22.5)
        {
            return Orientations.E;
        }
        else if (angle >= 22.5 && angle < 67.5)
        {
            return Orientations.NE;
        }
    }
Also try to keep consistency in your code. if you use return value in the if statement do that for both function, in you use it outside do it everywhere. 
Note that in your implementation of the AngleToVectorDirection you don't need to create a new vector in the beginning since you cover all the angle that can be. 
