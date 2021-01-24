      string folder = "one.two.three";
      string[] parts = folder.Split('.');
      string newFolder = string.Join("\\", Enumerable
        .Range(1, parts.Length)
        .Select(i => string.Join(".", parts.Take(i))));
      Console.Write(newFolder);
