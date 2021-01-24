C#
interface IinterfaceNew
{
  void MethodNew();
}
class Class3 : Iinterface, IinterfaceNew
{
 public void Method1() {}
 public void MethodNew() {}
}
If not, then just go ahead and write a normal method in the class3 :)
