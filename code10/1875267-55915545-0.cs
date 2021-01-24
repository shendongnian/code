    string s1 = "akhil";
    string s2 = "akhil";
    Console.WriteLine(s1.Equals(s2)); //true
    s2 = "akhil jain";
    Console.WriteLine(s1.Equals(s2)); //false
    string s3 = "akhil";
    Console.WriteLine(s3 + " " + s1);
    Console.WriteLine(s1.Equals(s3)); //true
    string s4 = "akhil1".Substring(0, 5);
    Console.WriteLine(s1.Equals(s4)); //this now returns true as well
    Console.WriteLine(s1 == s4);      //so does this
