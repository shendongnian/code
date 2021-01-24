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
