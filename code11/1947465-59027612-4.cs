      string prefix = "Project.Repositories.Methods";
      string source = "Project.Repositories.DataSets.Project.Repositories.Entity";
      // We have 2 cases when all starting characters are equal:
      string result = prefix.Length >= source.Length 
        ? ""
        : source.Substring(source.IndexOf('.', prefix.Length) + 1);
      int dotPosition = -1;
      for (int i = 0; i < Math.Min(prefix.Length, source.Length); ++i) {
        if (prefix[i] != source[i]) {
          result = source.Substring(dotPosition + 1);
          break;
        }
        else if (prefix[i] == '.')
          dotPosition = i;
      }
      Console.Write(result);
