foreach (var line in lines)
{
   var match = Regex.Match(line,@"(?<=2:\[X:)\d+");
   if(match.Success)
      Console.WriteLine(match.Value);  
}
**Option 2** : Simple `string.Split`
foreach (var line in lines)
{
   var results = line.Split(new[] { "2:[X:", "][Y:" }, StringSplitOptions.RemoveEmptyEntries);
   if(results.Length>1)
      Console.WriteLine(results[1]);
}
**Option 3** :  "Possibly" a more performant approach, using *Pointers* `fixed` and `unsafe`
    public static unsafe (bool found, int value) ParseLine(string line)
    {
       const string prefix = "2:[X:"; 
       fixed (char* pLine = line,pPrefix = prefix)
       {
     
          var pLen = line.Length + pLine;
          var found = false;
          var result = 0;
          var i = 0;
          for (char* p = pLine ,pP = pPrefix; p < pLen; p++)
          {
             if (!found )
             {
                if( *p == *(pP+i)) i++;
                if( i ==prefix.Length) found = true;
                continue;
             }
             
             if (*p < '0' || *p > '9')
                break;
    
             result = result * 10 + *p - '0';
    
     
          }
    
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
    | RegEx    | 3,358.3 us | 65.169 us | 66.923 us |
    | Split    | 1,980.9 us | 38.440 us | 48.614 us |
    | Pointers | 287.4 us   | 4.396 us  | 4.112 us  |
    +----------+------------+-----------+-----------+
**Test Code**
    public class Test
    {
       private Regex _regex;
    
       private string[] data;
    
       [GlobalSetup]
       public void Setup()
       {
          _regex = new Regex(@"(?<=2:\[X:)\d+", RegexOptions.Compiled);
    
          data = File.ReadLines(@"D:\Test3.txt")
                     .ToArray();
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
          return data.Select(line => line.Split(new[] { "2:[X:", "][Y:" }, StringSplitOptions.RemoveEmptyEntries))
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
          const string prefix = "2:[X:"; 
          fixed (char* pLine = line,pPrefix = prefix)
          {
        
             var pLen = line.Length + pLine;
             var found = false;
             var result = 0;
             var i = 0;
             for (char* p = pLine ,pP = pPrefix; p < pLen; p++)
             {
                if (!found )
                {
                   if( *p == *(pP+i)) i++;
                   if( i ==prefix.Length) found = true;
                   continue;
                }
                
                if (*p < '0' || *p > '9')
                   break;
    
                result = result * 10 + *p - '0';
    
        
             }
    
             return (found, result);
          }
       }
    }
