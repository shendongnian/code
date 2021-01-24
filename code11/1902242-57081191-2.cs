    string s = "hallo";
    string a = "hal";
    string b = "lo";
    // Constructed, so that we will get the same string value as `s`, but a different reference.
    string t = a + b;
    object o1 = s;
    object o2 = t;
    Console.WriteLine(s == t);   // ==> True
    Console.WriteLine(o1 == o2); // ==> False
    Console.WriteLine(s.Equals(t));   // ==> True
    Console.WriteLine(o1.Equals(o2)); // ==> True
