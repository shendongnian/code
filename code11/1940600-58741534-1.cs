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
or
public static int GetLeasingCharges(ILeasable leasable)
{
    if(leasable is ClubHouse) { 
        var property = leasable  as ClubHouse;
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
