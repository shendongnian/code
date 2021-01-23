    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        PrincipalPermission principalPerm = new PrincipalPermission(null, "Vendor Manager");
        try
        {
            principalPerm.Demand();
            Console.WriteLine("Demand succeeded.");
        }
        catch (Exception secEx)
        {
            Console.WriteLine("Demand failed.");
        }
        Console.ReadLine();
    }
