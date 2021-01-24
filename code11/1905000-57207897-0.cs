 csharp
public class Program
{
    public static void Main(string[] args)
    {
        var guests = new List<Guest>();
        var lines = File.ReadLines("path/to/your/file.txt");
        foreach (var line in lines)
        {
            // TODO: parse line and extract data into variable.
            // You're doing it already...
            var name = "";
            var nightsStaying = 0;
            var isCorporate = false; 
            guests.Add(new Guest(name, nightsStaying, isCorporate));
        }
        var outputLines = guests.Select(guest => GuestFormatter.Format(guest));
        File.WriteAllLines("path/to/your/output-file.txt", outputLines);
    }
}
public class Guest
{
    public Guest(string name, int nightsStaying, bool isCorporate)
    {
        Name = name;
        NightsStaying = nightsStaying;
        IsCorporate = isCorporate;
    }   
    public string Name { get; } 
    public int NightsStaying { get; }
    public bool IsCorporate { get; }
}
public static class GuestFormatter
{
    public static string Format(Guest guest)
    {
        return $"{guest.Name},{guest.NightsStaying},{guest.IsCorporate}";
    }
}
