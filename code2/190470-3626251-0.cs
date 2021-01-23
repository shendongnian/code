    using System.Linq;
    using System.IO;
    string path = ...;
    
    IEnumerable<char> invalidChars = Enumerable.Concat(
        Path.GetInvalidFileNameChars(),
        Path.GetInvalidPathChars());
    
    foreach (char c in invalidChars)
    {
        path = path.Replace(c, ''); // or any char you want
    }
