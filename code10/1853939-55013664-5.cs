    public static void Test(string param1, string param2)
    {
       Validator.Validate(x => param1);
    }
    
    public static void Main()
    {
       Test(null,"asdf");
    }
