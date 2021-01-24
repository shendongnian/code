    _updateTimer = new DispatcherTimer();
    _updateTimer.Tick += OnUpdate;
    _updateTimer.Interval = TimeSpan.FromSeconds(0.01);
    _updateTimer.Start();
    private void OnUpdate(object sender, EventArgs e)
    {
        var entryIndex = _rnd.Next(Prices.Count);
        var entry = Prices[entryIndex];
        OrderList list;
        list = _rnd.Next(2) == 1 ?
                   entry.BuyOrders :
                   entry.SellOrders;
        if (list.Any())
        {
            var order = list[_rnd.Next(list.Count)];
            order.Qty += _rnd.Next(0, 8) - 4;
        }
    }
