    // Get lines as list.
    var lines = GetFileLines(@"c:\test.txt").ToList();
    // Let's say that there were a few empty lines in the list.
    for (var i = 0; i < 5; i++) lines.Add(""); // Add a few empty lines.
    // Now, set the data source, and filter out the null/empty lines
    listBox1.DataSource = lines.Where(x => !string.IsNullOrEmpty(x));
    // ...
    // Or maybe you are interested in removing empty and just whitespace
    for (var i = 0; i < 5; i++) lines.Add("     "); // Add a few spaced lines
    listBox1.DataSource = lines.Where(x => !string.IsNullOrWhiteSpace(x));
