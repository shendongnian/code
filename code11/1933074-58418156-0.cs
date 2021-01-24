csharp
public interface IAddress
{
    string HouseNumber { get; set; }
    string FlatPosition { get; set; }
    string AddressLine { get; set; }
    string Town { get; set; }
    string County { get; set; }
    string Postcode { get; set; }
}
Then add your model classes like this:
csharp
public class LandLordAddress : IAddress
{
    [Column("LandLordHouseNumber")]
    public string HouseNumber { get; set; }
    ...
}
This way, you will at least be able to write more generic code to operate on instances of these classes.
