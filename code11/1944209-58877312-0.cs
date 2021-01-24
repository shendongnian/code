public interface IId
{
    int Id { get; set; }
}
public class Construction : IId
{
    public int Id { get; set; }
}
public void Delete(IId obj)
{
    var x = obj.Id;
}
You could use a constraint, please see [Constraints on type parameters (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters).
public void Delete2<T>(T obj) where T : Construction
{
   var x = obj.Id;
} 
