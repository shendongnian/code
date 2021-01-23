    String Original = "hi-this-is-a-string-15";
    Regex A = new Regex(@"^(.*)(-\d+)$");
     
    var ResultA = A.Match(Original);
     
    Console.Write("Found Match A: ");
    Console.WriteLine(ResultA.Groups[0]);
    
    Console.WriteLine(ResultA.Groups[1]);
    Console.WriteLine(ResultA.Groups[2]);
