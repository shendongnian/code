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
Your conditions were incorrect. Look at the `ShouldHostGrammyThisYear` method in `GrammyHost` class:
csharp
if (thisYear < Year)
{
    return false;
}
return ((thisYear - Year) % 3) == 0;
First we check if the this year is after the year that this person hosted grammy - if not then I return false here, because it does not make sense that this year is before the year this person hosted grammy - maybe we could throw exception here.
Then if you look at the return statement we calculate the difference to know how many years have passed since this year and check if the difference is divisible by 3. 
e.g. let's say `thisYear` is 1973 and `GrammyHost.Year` is 1970 (Tupac). The difference is 1973 - 1970 = 3. We check if difference is divisible by 3 using `%` operator. In a case of `Tupac` 3 is divisible by 3 so 3 % 3 will return 0 and that's why we compare to 0 `== 0`  
Also I think there is no need for a switch-case. 
