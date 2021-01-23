    string s = "55555555";
    Regex regx = new Regex(@"^(?:12345678|(\d)\1{7})$");
    if (!regx.IsMatch(s)) {
        Console.WriteLine("It does not match!!!");
    }
    else {
        Console.WriteLine("it matched");
    }
    Console.ReadLine();
