csharp
public class FullClass
{
    public int x;
    public int y;
    public int z;
}
public class CopyClass
{
    public int x;
    public int y;
}
public static class FullClassCopyClassConverter
{
    public static FullClass ToFullClass(CopyClass from)
    {
        return new FullClass
                {
                    x = from.x,
                    y = from.y,
                    z = default // ?
                };
    }
    public static CopyClass ToCopyClass(FullClass from)
    {
        return new CopyClass
                {
                    x = from.x,
                    y = from.y
                };
    }
}
This classes are testable and flexible.
----------
If you need easy-on-go solutions, take a look on libraries like [Automapper][1]
  [1]: https://automapper.org/
