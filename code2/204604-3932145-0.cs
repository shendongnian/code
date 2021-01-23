    static class MyExtensions
    {
        public static void MyFunc(this string arg)
        {
            // ...
        }
    }
    
    string a = "aa";
    MyExtensions.MyFunc(a); // OK
    a.MyFunc();             // same as above, but nicer
