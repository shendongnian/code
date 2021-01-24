      using System.Linq;
      ...
      string prefix = "Project.Repositories.Methods";
      string source = "Project.Repositories.DataSets.Project.Repositories.Entity";
      string[] prefixes = prefix.Split('.');
      string result = string.Join(".", source
        .Split('.')                                            // split into 
        .Select((value, index) => new { value, index})         // chunks  
        .SkipWhile(item => item.index < prefixes.Length &&     // skip
                           prefixes[item.index] == item.value) // common chunks
        .Select(item => item.value));
      Console.Write(result);
