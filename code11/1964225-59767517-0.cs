cs
public class MyCompoundKey : IEqualityComparer<MyCompoundKey>
{
    public bool Equals(MyCompoundKey b1, MyCompoundKey b2)
    {
        if (b2 == null && b1 == null)
           return true;
        else if (b1 == null || b2 == null)
           return false;
        else if(b1.Height == b2.Height && b1.Length == b2.Length
                            && b1.Width == b2.Width)
            return true;
        else
            return false;
    }
    public int GetHashCode(MyCompoundKey bx)
    {
        int hCode = bx.Height ^ bx.Length ^ bx.Width;
        return hCode.GetHashCode();
    }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public string Name { get; set; }
}
In the example above it ignores Name in the equality check.
