    string s = "AT+CPBR=1\r\r\n+CPBR: 1, \"0342123456\", 129, \"simnumber\"\r\n\r\nOK\r\n";
    Regex rx = new Regex(@": (\d), ""(\d+)"", (\d+), ""(\w+)""");
    Match m = rx.Match(s);
    Console.WriteLine(m.Groups[0]);
    Console.WriteLine(m.Groups[1]);
    Console.WriteLine(m.Groups[2]);
    Console.WriteLine(m.Groups[3]);
    Console.WriteLine(m.Groups[4]);
