    string s = "Stock: 4551 Items";
    string s2 = "Stock: 451 Items";
    string s3 = "Stock: 451 Red Items";
    Regex reg = new Regex(@"[^0-9]([6-9]|[1-9][0-9]|[1-4][0-9][0-9]|500)[^0-9]Items");
    
    Console.WriteLine(reg.IsMatch(s).ToString()); // false
    Console.WriteLine(reg.IsMatch(s2).ToString()); // true
    Console.WriteLine(reg.IsMatch(s3).ToString()); // false
