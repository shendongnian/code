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
