    Stream data = GetTheStream();
    // Boundary is auto-detected but can also be specified.
    var parser = new MultipartFormDataParser(data, Encoding.UTF8);
    // The stream is parsed, if it failed it will throw an exception. Now we can use
    // your data!
    // The key of these maps corresponds to the name field in your
    // form
    string username = parser.Parameters["username"].Data;
    string password = parser.Parameters["password"].Data
    // Single file access:
    var file = parser.Files.First();
    string filename = file.FileName;
    Stream data = file.Data;
    // Multi-file access
    foreach(var f in parser.Files)
    {
        // Do stuff with each file.
    }
