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
First we check if this year is valid in context of the current person. The host cannot travel back in time so if `thisYear` is before `GrammyHost.Year` we return false without further checks.
Then if you look at the return statement we calculate the difference to know how many years have passed sinced `GrammyHost.Year` to `thisYear` and check if the difference is divisible by 3. 
e.g. let's say `thisYear` is 1973 and `GrammyHost.Year` is 1970 (Tupac). The difference is `1973 - 1970 = 3`. We check if it is divisible by 3 using `%` operator. In a case of `Tupac` the difference is 3 and it is indeed divisible by 3, so 3 % 3 will result in 0. That's why we compare to 0 when we check if something is divisible by some number `== 0`.  
Also I think there is no need for a switch-case. 
