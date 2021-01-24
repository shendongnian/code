    while (!reader.EndOfStream)
    {
        var values = reader.ReadLine().Split(';');
        if(DateTime.TryParse(values.Skip(1).First(), out var date)) {
            orders.Add(Order.FromOrderWithDate(values));
        }
        else
            orders.Last().Items.Add(Item.FromOrderWithEmail(values));
    }
