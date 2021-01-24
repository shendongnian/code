public class MyClass
{
  static private int _status;
  static public int Status
  {
  }
}
MyClass.Status = 1;
In this case, all instances of MyClass share the same _status value that is common for all so there is only one _status in the whole app.
**Singleton**
public class MySingleton
{
  public readonly MySingleton = new MySingleton();
  private MySingleton()
  {
  }
  private int _status;
  public int Status
  {
  }
}
MySingleton.Instance.Status = 1;
In this case, only one instance of the class is allowed so there is only one _status in the whole app.
https://stackoverflow.com/questions/519520/difference-between-static-class-and-singleton-pattern
