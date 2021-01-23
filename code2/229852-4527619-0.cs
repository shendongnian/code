    using System.Linq;
    
    bool Contains(string input)
    {
        var arr = new[] { '\t', '\v', '\n', '\f', '\r', '\b', '\x7f', '\x99', '\a', .. };
        return arr.Any(c => input.Contains(c));
    }
