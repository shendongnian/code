    using System.IO;
    
    try {
        Directory.Move(@"c:\d1\d2\d3", @"c:\d1\new");
    } catch (UnauthorizedAccessException) {
        // Permission denied, recover...
    } catch (IOException) {
        // Other I/O error, recover...
    }
