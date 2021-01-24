public interface IData
{
  void SomeMethod();
}
public abstract class Data<T> : IData
{
  public void SomeMethod()
  {
  }
}
List<IData> list = new List<IData>();
foreach (var item in list)
  item.SomeMethod();
You can also use a non generic abstract class instead of an interface:
public abstract class DataBase
{
  public abstract void SomeMethod();
}
public abstract class Data<T> : DataBase
{
  public override void SomeMethod()
  {
  }
}
List<DataBase> list = new List<DataBase>();
foreach (var item in list)
  item.SomeMethod();
But you lost some genericity design and strong-typing...
And you may provide any non-generic behavior such as properties and methods you need to operate on.
