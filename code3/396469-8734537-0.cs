    public static class GlobalData
    {
        public static string[] Foo = new string[16];
    };
    
    // From anywhere in your code...
    Console.WriteLine(GlobalData.Foo[7]);
