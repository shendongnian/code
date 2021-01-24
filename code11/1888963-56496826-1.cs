    List<Coin> list = new List<Coin>
    {
        new Coin{Name="USDT", Value = 29},
        new Coin{Name="ETH", Value = 13},
        new Coin{Name="LTC", Value = 21},
        new Coin{Name="BTC", Value = 3},
    };
    // Take out USDT coin
    Coin USDTcoin = list.Find(coin => coin.Name == "USDT");
    list.RemoveAt(list.FindIndex(coin => coin.Name == "USDT"));
    // Order list
    list = list.OrderByDescending(coin => coin.Value).ToList();
    // Make new list
    list = new List<Coin>
    {
        list[0],
        USDTcoin
    };
