    files.Sort(delegate(string str1, string str2)
    {
        var pattern = @"(?<version>\d.*?$)";
        var version1 = System.Text.RegularExpressions.Regex.Match(str1, pattern).Groups["version"].Value;
        var version2 = System.Text.RegularExpressions.Regex.Match(str2, pattern).Groups["version"].Value;
        // TODO: Implement your version comparison logic here 
        return string.Compare(version1, version2);
    });
