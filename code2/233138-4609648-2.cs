    static void Main(string[] args)
    {
        AddressViewModel addressVm = new AddressViewModel
        {
            Line1 = "555 Honolulu Street",
            City = "Honolulu",
            State = "HI"
        };
    
        Address address = addressVm.Convert();
    
        Console.WriteLine(address.Line1);
        Console.WriteLine(address.City);
        Console.WriteLine(address.State);
        Console.ReadLine();
    }
