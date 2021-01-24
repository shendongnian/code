c#
public class MyClass 
{
    public int Id { get; set; }
    public int Amount { get; set; }
}
Let's say the myClass parameter has `Id = 1`, `Amount = 300`.
This works:
c#
public void DoSomething(MyClass myClass) 
{
    myClass.Amount = 500;
}
`myClass.Amount` has become `500`.
This does NOT work:
c#
public void DoSomething(MyClass myClass) 
{
    myClass = new MyClass()
    {
         Id = 5,
         Amount = 500
    }
}
`myClass.Amount` is still `300` and `myClass.Id` is `1`.
But, this DOES work:
c#
public void DoSomething(ref MyClass myClass) 
{
    myClass = new MyClass()
    {
         Id = 5,
         Amount = 500
    }
}
`myClass.Amount` is `500` and `myClass.Id` is `5`.
