    int i = 1;
    short s = 1;
    System.Console.WriteLine(i==s ? "Yes" : "No"); // Yes
    System.Console.WriteLine(i.CompareTo(s)==0 ? "Yes" : "No"); // Yes
    System.Console.WriteLine(s.CompareTo(i) == 0 ? "Yes" : "No"); // ERROR !
    System.Console.WriteLine(s.Equals(i) ? "Yes" : "No"); // No
    System.Console.WriteLine(i.Equals(s) ? "Yes" : "No"); // Yes
