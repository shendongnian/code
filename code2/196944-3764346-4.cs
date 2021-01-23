    using System.Text.RegularExpressions;
    var res = Regex.Match("hey @john how are you", @"@(\S+)");
    
    if (res.Success)
    {
        //john
        var name = res.Groups[1].Value;
    }
