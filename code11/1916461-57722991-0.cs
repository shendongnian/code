    using System.Linq;
    //...
    string input = "(False,False,False,True,False,False,False)";
    List<bool> result = input.Trim('(',')')                // Remove the leading and trailing braces
                             .Split(',')                   // Split all values by ',' into an array
                             .Select(bv => bool.Parse(bv)) // and convert them into a Boolean value
                             .ToList();                    // materialize them as a List if you need
