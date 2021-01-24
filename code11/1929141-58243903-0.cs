    foreach (var item in kart.GetKart())
    {
        var message = Deals.BuyOneGetOneFree(item); // <--- Here
        Console.WriteLine(message); // show return message
        Console.WriteLine(item.Item);          
    }
