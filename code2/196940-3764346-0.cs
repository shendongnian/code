    using System.Text.RegularExpressions;
    //Finds the first occurence. \S means anything else than a whitespace
    //maybe [a-zA-Z0-9] or similar would suit you better (depends on which characters the usernames is made of)
    var res = Regex.Match("hey @john how are you", @"@\S+");
    
    if (res.Success)
    {
        var name = res.Value;
    }
