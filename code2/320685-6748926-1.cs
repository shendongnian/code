    string literal = @"I 
    am
    the
    best"; //With \n
    string[] lines = literal.Split(new string[] { "\n" }, StringSplitOptions.None);
    string lastLine = lines[lines.Length - 1];
    Console.WriteLine(lastLine); //Should print "best"
