    Owner owner1 = new Owner { Name = "owner1" };
    Owner owner2 = new Owner { Name = "owner2" };
    Item anItem = new Item { Name = "item1" };
    
    owner1.Item = anItem;
    Console.WriteLine("---------------------------------");
    owner2.Item = anItem;
