    using System.Linq;
    ...
    Predicate<string> substringCheck = item => item.Contains(str);
                var exists = list.Any(substringCheck);
                var getMatch = list.First(substringCheck);
