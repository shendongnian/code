none
sport,date,team 1,team 2,score 1,score 2
basketball,2011/01/28,Rockets,Blazers,98,99
baseball,2011/08/22,Yankees,Redsox,4,3
You can add attributes to your class to map the field names to your class names like this:
cs
public class SportStats
{
    [Name("sport")]
    public string Sport { get; set; }
    [Name("date")]
    public DateTime Date { get; set; }
    [Name("team 1")]
    public string TeamOne { get; set; }
    [Name("team 2")]
    public string TeamTwo { get; set; }
    [Name("score 1")]
    public int ScoreOne { get; set; }
    [Name("score 2")]
    public int ScoreTwo { get; set; }
}
And then invoke like this:
List<SportStats> records;
using (var reader = new StreamReader(@".\stats.csv"))
using (var csv = new CsvReader(reader))
{
    records = csv.GetRecords<SportStats>().ToList();
}
### b) CSV *without* Headers
If your csv doesn't have headers like this:
none
basketball,2011/01/28,Rockets,Blazers,98,99
baseball,2011/08/22,Yankees,Redsox,4,3
You can add attributes to your class and map to the CSV ordinally by position like this:
cs
public class SportStats
{
    [Index(0)]
    public string Sport { get; set; }
    [Index(1)]
    public DateTime Date { get; set; }
    [Index(2)]
    public string TeamOne { get; set; }
    [Index(3)]
    public string TeamTwo { get; set; }
    [Index(4)]
    public int ScoreOne { get; set; }
    [Index(5)]
    public int ScoreTwo { get; set; }
}
And then invoke like this:
List<SportStats> records;
using (var reader = new StreamReader(@".\stats.csv"))
using (var csv = new CsvReader(reader))
{
    csv.Configuration.HasHeaderRecord = false;
    records = csv.GetRecords<SportStats>().ToList();
}
### Further Reading
* [Reading CSV file and storing values into an array][7] (295)
* [Parsing CSV files in C#, with header][9] (245)
* [Import CSV file to strongly typed data structure in .Net][6] (104)
* [Reading a CSV file in .NET?][5] (45)
* [Is there a “proper” way to read CSV files][8] (17)
* ... many more
[1]: https://github.com/JoshClose/CsvHelper
[2]: https://joshclose.github.io/CsvHelper/getting-started/
[3]: https://www.nuget.org/packages/CsvHelper/
[4]: https://i.stack.imgur.com/RaOZM.png
[5]: https://stackoverflow.com/q/1405038/1366033
[6]: https://stackoverflow.com/q/1898/1366033
[7]: https://stackoverflow.com/q/5282999/1366033
[8]: https://stackoverflow.com/a/2315182/1366033
[9]: https://stackoverflow.com/q/2081418/1366033
