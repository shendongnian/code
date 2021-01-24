C#
public class Flow<T> : IFlow
{
  public T Value { get; private set; }
  public Exception Exception { get; private set; }
  public bool Success => Exception is null;
  public bool Failure => !Success;
  public void Fail(Exception exception) => Exception = exception;
  public Flow(T value) => Data = value;
  public Flow(Exception exception) => Fail(exception);
  public static Flow<T> FromValue<T>(T data) => new Flow<T>(data);
}
public interface IFlow
{
  bool Success { get; }
  bool Failure { get; }
  Exception Exception { get; }
  void Fail(Exception exception);
}
The resulting custom IDataflow
=======
The following part looks scary, but don't be. It's essentially a TransformBlock wrapper with two extra features: 
