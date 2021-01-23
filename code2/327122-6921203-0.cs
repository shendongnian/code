    string a = "a";
    string b = a;
    Console.WriteLine(object.ReferenceEquals(a, b)); // true
    Console.WriteLine(a); // a
    Console.WriteLine(b); // a
    b += "b";
    Console.WriteLine(object.ReferenceEquals(a, b)); // false
    Console.WriteLine(a); // a
    Console.WriteLine(b); // ab
