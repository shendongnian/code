`csharp
public interface IRGBType { }
public struct RGBFloat : IRGBType
{
    public float R { get; }
    public float G { get; }
    public float B { get; }
    public RGBFloat(float r, float g, float b)
    {
        R = r;
        G = g;
        B = b;
    }
}
public struct RGBByte : IRGBType
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public RGBByte(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}
`
You can then have your generic class only accept types that implement this interface:
`csharp
public class Texture2D<T> where T: IRGBType
{
  ...
}
`
If you know that you'll always have this interface implemented by a `struct`, you can further restrict the generic:
`csharp
public class Texture2D<T> where T: struct, IRGBType
{
  ...
}
`
**EDIT:** Make sure to use the generic `T` parameter everywhere in your class, not the interface. This is necessary to ensure type safety, otherwise your indexers can accept *any* `IRGBType`, which can be very problematic. Correct usage:
`csharp
public class Texture2D<T> where T: struct, IRGBType
{
  private T[] _buffer;
  public Texture2D(int width, int height)
  {
      ...
      _buffer = new T[width * height];
      ...
  }
  public T this[int i]
  {
      get => _buffer[i];
      set => _buffer[i] = value;
  }
}
`
