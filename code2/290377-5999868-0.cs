    void Test(int x, dynamic y)
    {
        x = 3; 
        y.a = "four";
        y.b = "five";
        y = new {a = "six", b = "seven"}; // this will have no effect outside the function
    }
    int x = 2; // value type
    var y = new {a = "one", b="two"}; //reference type
    Test(x, y);
    Console.WriteLine(x);  //writes 2, because the test function is working with a copy
    Console.WriteLine(y.a); //writes four
    Console.WriteLine(y.b); //writes five
  
