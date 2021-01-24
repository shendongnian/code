    GetAccountBalanceResponseModel model = JsonConvert.DeserializeObject<GetAccountBalanceResponseModel>(json);    
    
    foreach (var item in model.status.Customer)
    {
        Console.WriteLine("Key: " + item.Key);
        Console.WriteLine("Id: " + item.Value.id);
        Console.WriteLine("FirstName: " + item.Value.FirstName);
        Console.WriteLine("LastName: " + item.Value.LastName);
        Console.WriteLine();
    }
    
