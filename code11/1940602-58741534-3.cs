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
# Just `ClubHouse`
int GetLeasingCharges(ILeasable leasable)
         => leasable is ClubHouse x
                ? x.AreaInSquareFeet * 10
                : 0;
int GetLeasingCharges(ILeasable leasable)
{
    var property = leasable as ClubHouse;
    if (property != null)
    {
        return property.AreaInSquareFeet * 10;
    }
    return 0;
}
# Test
internal class ClubHouse : ILeasable{ public int AreaInSquareFeet { get; set; } }
internal class X : ILeasable {}
internal interface ILeasable {}
class Program
{
    public static int GetLeasingCharges(ILeasable leasable)
        => leasable is ClubHouse x
            ? x.AreaInSquareFeet * 10
            : 0;
    static void Main(string[] args)
    {
        var c = new ClubHouse() { AreaInSquareFeet = 7500 };
        Console.WriteLine(GetLeasingCharges(c));
        var x = new X();
        Console.WriteLine(GetLeasingCharges(x));
    }
}
75000
0
