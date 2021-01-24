    if (e.UserState != null) 
    {
        Data.Add(new Operations() 
        {
            id = rnd.Next(1,999),
            name = Factory.name,
            qtyStock = Factory.Stock,
            averageStock = Factory.AverageStock,
            week = Factory.Week
        });
        listview.ItemsSource = Data;
    }
