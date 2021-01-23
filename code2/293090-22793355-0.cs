    var array = System.IO.File.ReadAllLines(openFileDialogLas.FileName)
        .Where(line => !String.IsNullOrWhiteSpace(line)) // Use this to filter blank lines.
        .Select(line => line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries))
        .Select(line => line.Select(element => double.Parse(element)))
        .Select(line => line.ToArray())
        .ToArray();
    
    Console.WriteLine("Number of Rows:      {0,3}", array.Length);
    Console.WriteLine("Number of Cols:      {0,3}", array[0].Length);
