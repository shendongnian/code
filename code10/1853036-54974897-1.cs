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
   if(results.Length>0)
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
