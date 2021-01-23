    Regex r = new Regex(@"^(\1.|^.)+$");
    
    Console.WriteLine(r.IsMatch("aababc"));     // True
    Console.WriteLine(r.IsMatch("1121231234")); // True
    Console.WriteLine(r.IsMatch("iLoveRegEx")); // False
    
    for (int n = 0; n <= 50; n++) {
        Match m = r.Match("".PadLeft(n));
        if (m.Success) {
           Console.WriteLine("{0} = sum(1..{1})", n, m.Groups[1].Length);
        }
    }
    // 1 = sum(1..1)
    // 3 = sum(1..2)
    // 6 = sum(1..3)
    // 10 = sum(1..4)
    // 15 = sum(1..5)
    // 21 = sum(1..6)
    // 28 = sum(1..7)
    // 36 = sum(1..8)
    // 45 = sum(1..9)
