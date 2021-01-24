cs
public abstract class Shape
{
    public abstract int Sides { get; }
    public abstract void Draw();
}
You can also define some common logic in this abstract class. Another option is to define `Shape` as an `interface`
