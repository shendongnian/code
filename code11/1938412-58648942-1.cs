public interface IMedia<T>
where T : IComparable, IFormattable, IConvertible
{
  T Id { get; set; }
}
Usage:
public class Book : IMedia<int>
{
  public int Id { get; set; }
}
public class Movie : IMedia<long>
{
  public long Id { get; set; }
}
Because there is no true generic polymorphism in C#, it may can't help you... and even with, `int` (4 bytes) and `long` (8 bytes) are two different types.
[About the lack of true generic polymorphism and the missing diamond operator in C#](https://stackoverflow.com/questions/58570948/how-to-create-list-of-open-generic-type-of-classt/58571001#58571001)
