csharp
public class Triangle: Polygon
{
    public Triangle(Point2D[] vertices) : base(vertices, 3){}
}
public class Quadrilateral: Polygon
{
    public Quadrilateral(Point2D[] vertices) : base(vertices, 4){}
}
The other goal that I was trying to accomplish (with the original example), was early validation.  In other words, if the correct number of vertices is not passed for the derived type, I want to stop initialization before any other initialization steps are performed on an invalid object.  In the given example, an empty default constructor and validation within the derived constructor (or even a call to a validation method contained in the base method from the derived constructor) would be fine, not passing the vertices to the base, rather validating and then setting them in the derived constructor.  However, the key is early validation, what if the base class does a bunch of stuff (a more complex class) to (pre)initialize the object before getting to the derived class.  Validation code really belongs before any processing (including initialization).
By passing a (validation related) value to the base constructor allows the validation to occur at the beginning, so as to prevent other code from running if the validation fails.
csharp
protected Polygon(Point2D[] vertices, int expectedVerticesCount)
{
    // Don't bother initializing the object, the data is invalid!
    if(vertices.Length != expectedVerticesCount)
        throw new ArgumentOutOfRangeException( /* ... */);
    // The data is valid, proceed with initialization
    Vertices = vertices;
}
