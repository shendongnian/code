    var findMe = "calc";
    var pathes = Environment.GetEnvironmentVariable("Path").Split(';');
    foreach (var path in pathes)
    {
         var testMe = $@"{path}\{findMe}.exe";
        if (File.Exists(testMe))
        {
             Console.WriteLine(testMe);
        }
    }
