    string zplSample  = "^XA blah blah blah ^XZ\r\n";
    string zplSample1 = "^XA blah blah \"blah ^XZ\r\n";
    Console.WriteLine(new Regex(@"\^XA.*\^XZ\r\n").IsMatch(zplSample));
    Console.WriteLine(new Regex(@"\^XA.*\^XZ\r\n").IsMatch(zplSample1));
    Console.ReadKey();
