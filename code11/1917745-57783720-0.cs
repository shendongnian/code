     using System.Text.RegularExpressions;
     ...
     string source = "1234-5678-91011-ABCD-EFGH";
     // 1234-5678-91011
     string result = Regex.Match(source, "[0-9]+-[0-9]+-[0-9]+").Value;
