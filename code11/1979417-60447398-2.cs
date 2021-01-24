     using System.Linq;
     ...
    var carraigeReturn = new[] { "\r\n", "\r", "\n" };
    var inputStrings = new [] {"your input strings"};
    
    for(int i= 0; i < inputStrings.Length; i++)
    {
        //Any will check any of the carriage return present in an array. 
        //If you want to check all then use .All()
        if(!carraigeReturn.Any(x => inputStrings[i].EndsWith(x))
              inputStrings[i] = $"{inputStrings[i]}\r\n";
    }
