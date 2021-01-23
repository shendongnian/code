    using System.Linq;
    ...
    Func<string, bool> substringCheck = item => item.Contains(str);
                var exists = list.Any(substringCheck);
                var getMatch = list.First(substringCheck);
