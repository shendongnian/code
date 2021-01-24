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
Perhaps you can do something like this:
public abstract class ObjectWithId
{
  private long _Id;
  public int IdAsInt
  {
    get { return checked((int)_Id); }
    set { _Id = (long)value; }
  }
  public long IdAsLong
  {
    get { return _Id; }
    set { _Id = value; }
  }
}
public class Book : ObjectWithId
{
}
public class Movie : ObjectWithId
{
}
You can create an interface if you need:
public interface IObjectWithId
{
  public int IdAsInt { get; set; }
  public long IdAsLong { get; set; }
}
But you say classes are auto-generated... so can you modify them with interface or abstract parent? 
And if you can, why not standardize Ids?
