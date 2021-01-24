csharp
// base class 
public class MyObject
{
    public int Id { get; set; }
    public string Name { get; set; }
}
// derived class
public class MyObjectA : MyObject
{
    public string Val01 { get; set; }
    public string Val02 { get; set; }
}
public class MyObjectB : MyObject
{
    public string Val03 { get; set; }
    public string Val04 { get; set; }
}
public class MyObjectC : MyObject
{
    public string Val05 { get; set; }
    public string Val06 { get; set; }
}
View :
Razor
switch (type)
{
   case MyObjectA :
      return PartialView("_CreateQWE", MyObjectA );
   case MyObjectB :
      return PartialView("_CreateASD", MyObjectB );
   case MyObjectC :
      return PartialView("_CreateZXC", MyObjectC );
}
or even you can create a enums property to distinguish your modals.
