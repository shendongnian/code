    public void MyTestMethod(string s) { }
    object o = "Hello StackOverflow!";
    Console.WriteLine(o.GetType() == typeof(string)); // true
    Console.WriteLine(o is string); // true
    MyTestMethod(o); // error: cannot convert object to string
