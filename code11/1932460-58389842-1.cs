    using System.IO;
    using System.Linq;
    ...
    var files = Directory
      .EnumerateDirectories( @"\\Computer1\", "*", SearchOption.TopDirectoryOnly)
      .SelectMany(dir => Directory
         .EnumerateFiles(dir, "Application.exe", SearchOption.TopDirectoryOnly)); 
    
    foreach (var file in files) {
    ...
    }
