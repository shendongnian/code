    System.IO.Path.IsPathRooted(@"c:\foo"); // true
    System.IO.Path.IsPathRooted(@"\foo"); // true
    System.IO.Path.IsPathRooted("foo"); // false
    System.IO.Path.IsPathRooted(@"c:1\foo"); // surprisingly also true
    System.IO.Path.GetFullPath(@"c:1\foo");// returns "[current working directory]\1\foo"
