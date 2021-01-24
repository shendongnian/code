foreach (var line in lines)
{
   var match = Regex.Match(line,@"(?<=X:)\d+");
   if(match.Success)
      Console.WriteLine(match.Value);  
}
**Option 2** : Simple `string.Split`
foreach (var line in lines)
{
   var results = line.Split(new[] { "X:", "][Y:" }, StringSplitOptions.RemoveEmptyEntries);
   if(results.Length>1)
      Console.WriteLine(results[1]);
}
**Option 3** :  "Possibly" a more performant approach, using *Pointers* `fixed` and `unsafe`
    public static unsafe (bool found, int value) ParseLine(string line)
    {
       fixed (char* pLine = line)
       {
          var pLen = line.Length + pLine;
          var found = false;
          var result = 0;
          for (var p = pLine; p < pLen; p++)
             if (*p == 'X')  found = true;           // start with X
             else if (!found || *p == ':') continue; // ignore everything before :
             else if (*p < '0' || *p > '9') break;   // short circuit when we have a result
             else result = result * 10 + *p - '0';   // accumulation 
    
          return (found, result);
       }
    }
    
    ...
    var results = File.ReadLines(@"D:\Test.txt")
                      .Select(ParseLine)
                      .Where(result => result.found)
                      .Select(result => result.value);
    
    foreach (var result in results)
       Console.WriteLine(result);
---
***Note** : this is not about regex bashing, just different approaches.*
I haven't benchedmarked this, however my suspicion is the *Pointers* will be the fastest, `split` will come next, and *Regex* will possibly be the slowest (even if using compiled), however it is the most readable and maintainable and also robust approach (which is why i put it first)
#Benchmarks
    +----------+------------+-----------+-----------+
    |  Method  |    Mean    |   Error   |  StdDev   |
    +----------+------------+-----------+-----------+
    | RegEx    | 3,434.5 us | 67.999 us | 69.830 us |
    | Split    | 2,008.9 us | 26.415 us | 24.709 us |
    | Pointers | 262.5 us   | 2.527 us  | 2.110 us  |
    +----------+------------+-----------+-----------+
**Test Code**
    private string[] data;
    
    private Regex _regex;
    
    [GlobalSetup]
    public void Setup()
    {
       _regex = new Regex(@"(?<=X:)\d+",RegexOptions.Compiled);
       data = File.ReadLines(@"D:\Test3.txt").ToArray();
    }
    
    [Benchmark]
    public List<int> RegEx()
    {
       return data.Select(line => _regex.Match(line))
                  .Where(x => x.Success)
                  .Select(match => int.Parse(match.Value))
                  .ToList();
    }
    
    [Benchmark]
    public List<int> Split()
    {
       return data.Select(line => line.Split(new[] { "X:", "][Y:" }, StringSplitOptions.RemoveEmptyEntries))
                      .Where(results => results.Length > 1)
                      .Select(results => int.Parse(results[1]))
                      .ToList();
    }
    
    [Benchmark]
    public List<int> Pointers()
    {
       return data.Select(ParseLine)
                  .Where(result => result.found)
                  .Select(result => result.value)
                  .ToList();
    }
    
    public static unsafe (bool found, int value) ParseLine(string line)
    {
       fixed (char* pLine = line)
       {
          var pLen = line.Length + pLine;
          var found = false;
          var result = 0;
    
          for (var p = pLine; p < pLen; p++)
             if (*p == 'X')
                found = true;
             else if (!found || *p == ':')
                continue;
             else if (*p < '0' || *p > '9')
                break;
             else
                result = result * 10 + *p - '0';
    
          return (found, result);
       }
    }
