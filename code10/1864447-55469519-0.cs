      // HashSet<string> is faster for Contains then string[]: O(1) vs. O(N)
      HashSet<string> Ids = new HashSet<string>() {
        "011911772",
        "123456789",
      };
      string[] dirsToScan = new string[] {
        @"c:\Utilisateurs",
        @"d:\MyFiles",
        @"c:\SomeOtherDir\SomeFolder",
      };
      var regex = new Regex("[0-9]+$"); 
      //TODO: check search options (and restrict if possible)
      var files = dirsToScan
        .SelectMany(dir => Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories))
        .Where(file => {
          var match = regex.Match(Path.GetFileNameWithoutExtension(file));
          return match.Success && Ids.Contains(match.Value);
        })
        .ToArray(); // Let's materialize as an array
