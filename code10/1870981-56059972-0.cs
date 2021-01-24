    <#@ import namespace="System.IO" #>
    <#@ template debug="false" hostspecific="true" language="C#" #>
    <# 
    string path = this.Host.ResolvePath(@"PocoClass.cs");
    var PocoLines= File.ReadLines(path).ToArray();
    List<string> usingStatements = new List<string>();
    foreach (var line in pocoLines)
    {
        if(Regex.Match(line, "RegexForUsings") //or use String.Contains("using");
            usingStatements.Add(line);
    }
    //insert lines again in PocoLines
    #>
