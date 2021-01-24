csharp
class GrammyHost
{
    public GrammyHost(string name, int year)
    {
        Name = name;
        Year = year;
    }
    public string Name { get; }
    public int Year { get; }
    public bool ShouldHostGrammyThisYear(int thisYear)
    {
        if (thisYear < Year)
        {
            return false;
        }
        return ((thisYear - Year) % 3) == 0;
    }
}
class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the year: ");
        // Let's create a list of possible hosts
        var grammyHosts = new List<GrammyHost>
        {
            new GrammyHost("Tupac", 1970),
            new GrammyHost("Usher", 1971),
            new GrammyHost("Mario", 1972)
        };
        var thisYear = 0;
        thisYear = int.Parse(Console.ReadLine());
        // Search for this year host
        var thisYearHost = grammyHosts
            .FirstOrDefault(host => host.ShouldHostGrammyThisYear(thisYear));
        // If it's null then there is no host this year...
        if (thisYearHost is null)
        {
            Console.Write("No host this year...");
        }
        else // Otherwise print the host
        {
            Console.Write("Hello {0}, you are the host of year {1}", thisYearHost.Name, thisYear);
        }
        Console.ReadLine();
    }
}
Your conditions were incorrect. Look at the `ShouldHostGrammyThisYear` method in `GrammyHost` class, also I think there is no need for a switch-case. 
