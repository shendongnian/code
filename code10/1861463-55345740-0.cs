    order.Sum(character =>
    {
        int id = character - '0';
        if (items.TryGetValue(id, out double price))
        {
            return price;
        }
        else
        {
            return 0d;
        }
    });
