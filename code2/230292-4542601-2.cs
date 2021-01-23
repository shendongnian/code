    public class 3dArrayLocation {public int X; public int Y; public int Z;}
    ...
    public 3dArrayLocation GetElementLocation(...)
    {
        // calculate x, y, and z
        return new 3dArrayLocation {X = x, Y = y, Z = z}
    }
    ...
 
    var location = GetElementLocation(...);
    doubleArray[location.X, location.Y, location.Z] = 5.0;
