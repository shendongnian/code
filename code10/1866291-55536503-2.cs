    public static Order FromRow(string[] ordered) =>  
        new Order {
        Type = ordered[0],
        Date = DateTime.Parse(ordered[1]),
        OrderID = ordered[2],
        Email = ordered[3],
        Items = new List<Item>();
    };
    public static Item FromRow(string[] items) =>  
        new Item {
        Type = items[0],
        OrderID = items[1],
        ItemNumber = items[2],
        Quantity = int.Parse(items[3])
    };
