    using System.Text.RegularExpressions;
    RegEx rx(@"I(\d+)P(\d+)\.jpg");
    Match m = rx.Match("I1P706.jpg");
    if(m.Success)
    {
        // m.Groups[1].Value contains the first number
        // m.Groups[2].Value contains the second number
    }
    else
    {
        // not found...
    }
