    Regex foo = new Regex(@"_Rev\.\s(\d)\.(\d\d)$");
    GroupCollection groups = foo.Match("Filename_Rev. 1.00").Groups;
    string majorNum = groups[1].Value;
    string minorNum = groups[2].Value;
    System.Console.WriteLine(majorNum);
    System.Console.WriteLine(minorNum);
