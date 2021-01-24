      using System.Reflection;
     ...
      var result = typeof(Test)
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(info => $"{(info.IsPrivate ? "private" : "not private")} {info.Name}");
      string report = string.Join(Environment.NewLine, result);
      Consolw.Write(report);
