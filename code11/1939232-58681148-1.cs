    using System.Collections.Generic;
    using System.Linq;
    
    List<string> stringList = new List<string>() {"f","o","o","b","a","r"};
        string givenString = "á";
        List<string> resultList = stringList.Where(item=> item.Contains(givenString.Replace('á', 'a'))).ToList();
    
    foreach (var value in resultList) {
        Console.WriteLine(value);
    }
