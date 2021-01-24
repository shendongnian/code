public interface IMyInterface
{
  void SomeMethod();
}
public abstract class Data<T> : IMyInterface
{
  public void SomeMethod()
  {
  }
}
List<IMyInterface> list = new List<IMyInterface>();
foreach (var item in list)
  item.SomeMethod();
You can also use a non generic abstract class instead of an interface:
public abstract class BaseClass
{
  void SomeMethod();
}
public abstract class Data<T> : BaseClass
{
  public void SomeMethod()
  {
  }
}
List<BaseClass> list = new List<BaseClass>();
foreach (var item in list)
  item.SomeMethod();
But you lost some genericity design and strong-typing...
And you must provide any non-generic behavior such as properties and methods you need to operate on.
