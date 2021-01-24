internal interface ILeasable
{
  int Id { get; set; }
  int GetLeasingCharges();
}
internal class ClubHouse : ILeasable
{
  public int Id { get; set; }
  public int AreaInSquareFeet { get; set; }
  public int GetLeasingCharges() => AreaInSquareFeet * 10;
}
internal class ClubHouse : ILeasable
{
  public int Id { get; set; }
  public int CarCapcity{ get; set; }
  public int GetLeasingCharges() => CarCapcity * 15;
}
# B. `GetLeasingCharges` not part `ILeasable`
From `C#7.0` you can use [pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching) for situations like this. 
public static int GetLeasingCharges(ILeasable leasable)
{
    // From c#7.0
    switch (leasable)
    {
        case ClubHouse c:
            return c.AreaInSquareFeet * 10;
        case ShowRoom s:
            return s.AreaInSquareFeet * 12;
        case Parking p:
            throw new ArgumentException(
                message: "Parkings cannot be leased!",
                paramName: nameof(leasable));
        default:
            throw new ArgumentException(
                message: "Unknown type",
                paramName: nameof(leasable));
    }
}
Before `C#7.0` you could use `if`.
if (leasable is ClubHouse)
{
    var c = (ClubHouse)leasable;
    return c.AreaInSquareFeet * 10;
} 
else if (leasable is ShowRoom)
{
    var c = (ShowRoom)leasable;
    return s.AreaInSquareFeet * 12;
}
else if(leasable is Parking)
{
    throw new ArgumentException(
         message: "Parkings cannot be leased!",
         paramName: nameof(leasable));
}
else 
{
    throw new ArgumentException(
        message: "Unknown type",
        paramName: nameof(leasable));
}
