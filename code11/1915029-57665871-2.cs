    int quantity = int.Parse(Console.ReadLine());
    if (part == 1)
    {
        Invoice invoice1 = new Invoice("A2507", 16.25m);
        invoice1.Quantity = quantity;
        invoice1.DisplayOrder();
    }
