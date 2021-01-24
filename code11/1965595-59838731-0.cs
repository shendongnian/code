        List<Balance> actives = item.GetItems();
        List<Reserve> liabilities = Reserve.GetLiabilities();
        List<MainTable> main= new List<MainTable>();
                    foreach(var active in actives)
                    {
                        foreach(var liability in liabilities)
                        {
                            if (active.AssetId == liability.AssetId)
                            {
                                main.Add(new MainTable
                                {
                                    Active = active.Balance,
                                    Liability = liability.Deposits,
                                    AssetId = active.AssetId
                                });
                            }
                        }
                    }
