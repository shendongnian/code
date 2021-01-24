    var items = new List<Item>
    {
        new Item("Item1", new DateTime(2017, 1, 1), "oz", 10),
        new Item("Item1", new DateTime(2017, 1, 1), "lb", 150),
        new Item("Item1", new DateTime(2018, 1, 1), "oz", 11),
        new Item("Item1", new DateTime(2018, 1, 1), "lb", 160),
        new Item("Item1", new DateTime(2019, 1, 1), "oz", 12),
        new Item("Item1", new DateTime(2019, 1, 1), "lb", 170),
        new Item("Item2", new DateTime(2017, 1, 1), "oz", 21),
        new Item("Item2", new DateTime(2017, 1, 1), "lb", 220),
        new Item("Item2", new DateTime(2018, 1, 1), "oz", 22),
        new Item("Item2", new DateTime(2018, 1, 1), "lb", 225),
        new Item("Item2", new DateTime(2019, 1, 1), "oz", 23),
        new Item("Item2", new DateTime(2019, 1, 1), "lb", 235),
    };
    var bills = new List<Bill>
    {
        new Bill {ItemId = "Item1", Date = new DateTime(2017, 5, 4)},
        new Bill {ItemId = "Item1", Date = new DateTime(2019, 7, 1)},
        new Bill {ItemId = "Item2", Date = new DateTime(2018, 5, 4)},
        new Bill {ItemId = "Item3", Date = new DateTime(2019, 5, 4)},
    };
