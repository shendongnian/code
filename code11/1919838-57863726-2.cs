    static void Main(string[] args)
    {
        IManufacturerRepository repo = new ActualIManufacturerRepository();
        List<IManufacturer> mfgs = repo.GetManufacturers();
        PhoneTypeChecker checker = new PhoneTypeChecker( mfgs.Single( m => m.Name == "Samsung" ) );
        checker.CheckProducts();
        Console.ReadLine();
        checker = new PhoneTypeChecker( mfgs.Single( m => m.Name == "HTC" ) );
        checker.CheckProducts();
        Console.ReadLine();
        checker = new PhoneTypeChecker( mfgs.Single( m => m.Name == "Nokia" ) );
        checker.CheckProducts();
        Console.Read();
    }
