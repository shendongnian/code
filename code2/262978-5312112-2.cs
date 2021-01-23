    string[] lines = @"C:/User Permissions.txt"; string t = File.ReadAllLines(path);
    int line = 0;
    while (line < lines.Length) {
      if (lines[line].StartsWith("User Type ") {
        Console.WriteLine("User type:" + lines[line].Substring(10));
      } else if (lines[line].StartsWith("Users of this Type:") {
        line++;
        while (line < lines.Length && !lines[line].StartsWith("Permissions for these users:")) {
          Console.WriteLine("User: " + lines[line]);
          line++;
        }
      } else if (lines[line].StartsWith("Permissions for these users:") {
        Console.WriteLine("Permissions:" + lines[line].Substring(28));
      }
      line++;
    }
