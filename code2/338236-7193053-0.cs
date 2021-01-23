    using System.Text.RegularExpressions;
    var s = "Test 123 Test - ID 589";
    var match = Regex.Match(s, @"ID (\d+)$");
    int? id = null;
    if (match.Success) {
      id = int.Parse(match.Groups[1].Value);    
    }
