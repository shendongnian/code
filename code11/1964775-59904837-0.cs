       private class ShopRefillData
        {
            public ShopRefillData(decimal money, byte[] version)
            {
                CurrentMoney = money;
                Version = version;
            }
            public decimal CurrentMoney { get; set; }
            public byte[] Version { get; set; }
            public decimal Cost { get; set; }
            public decimal NewMoney => CurrentMoney - Cost;
        }
        private class ItemRefillData
        {
            public ItemRefillData(int currentQty, int qtyToRemove, byte[] version)
            {
                CurrentQty = currentQty;
                QtyToRemove = qtyToRemove;
                Version = version;
            }
            public int CurrentQty { get; set; }
            public int QtyToRemove { get; private set; }
            public byte[] Version { get; set; }
            public int NewQty => CurrentQty - QtyToRemove;
        }
        public async Task<int> RefillStockForAllAsync()
        {
            var charIdsQuery = Query.Select(x => x.Id);
            var DbF = EF.Functions;
            var currentDay = (DateTime?)DateTime.UtcNow.Date;
            //Reflect all users logged in on current day, the shop will only refill to match the demand of active users.
            var qty = await _db.Users.Where(x => DbF.DateDiffDay(x.LastLoginAt,currentDay) == 0).CountAsync() * 10;
            var query = _db.Items.
                Where(x => charIdsQuery.Contains(x.CharacterId) && x.State == Models.Areas.Game.Enums.ItemState.ShopSale)
                .Select(x => new ItemRefillViewModel {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    CharacterId = x.CharacterId,
                    Cost = x.Detail.Properties.Where(z => z.Key == ItemConstant.KEY_STATS_COST).Select(z => z.ValueDecimal).FirstOrDefault() ?? 0,
                    RowVersion = x.RowVersion
                }).OrderBy(x => x.CharacterId).ThenBy(x => x.Quantity);
            int currentShopId = -1;
            int updates = 0;
            var helper = await BatchHelper<ItemRefillViewModel>.CreateAsync(query,1,200);
            var shopData = new Dictionary<int, ShopRefillData>();
            var itemData = new Dictionary<long, ItemRefillData>();
            for (int i = 1; i <= helper.TotalPages; i++)
            {
                var items = await helper.GetBatch(i).ToArrayAsync();
                shopData.Clear();
                itemData.Clear();
                foreach (var item in items)
                {
                    int qtyToBuy = qty - item.Quantity;
                    if (qtyToBuy < 1) continue; //has enough qty
                    decimal cost = qtyToBuy * item.Cost * 0.70m;
                    if (currentShopId != item.CharacterId)
                    {
                        currentShopId = item.CharacterId;
                        var info = await _db.CharacterProperties.Where(x => x.CharacterId == currentShopId && x.Key == CharacterConstant.KEY_MONEY)
                            .Select(x => new { ShopMoney = x.ValueDecimal, x.RowVersion })
                            .FirstOrDefaultAsync();
                        
                        if(info != null && !shopData.ContainsKey(currentShopId))
                        {
                            shopData[currentShopId] = new ShopRefillData(info.ShopMoney ?? 0,info.RowVersion);
                        }
                    }
                    if (cost > shopData[currentShopId].CurrentMoney) continue; // cannot buy batch
                    shopData[currentShopId].Cost += cost;
                    itemData[item.Id] = new ItemRefillData(item.Quantity, qtyToBuy, item.RowVersion);
                }
                //Begin saving the batch
                using var transaction = await _db.Database.BeginTransactionAsync();
                try
                {
                    var updated = 0;
                    foreach (var sItem in shopData)
                    {
                        updated = await _db.CharacterProperties.Where(x => x.CharacterId == sItem.Key && 
                        x.Key == CharacterConstant.KEY_MONEY && x.RowVersion == sItem.Value.Version)
                            .UpdateAsync(x => new CharacterProperty() { ValueDecimal = sItem.Value.NewMoney });
                        if(updated == 0)
                        {
                            //concurrency check
                            var info = await _db.CharacterProperties.Where(x => x.CharacterId == currentShopId && x.Key == CharacterConstant.KEY_MONEY)
                                .Select(x => new { ShopMoney = x.ValueDecimal, x.RowVersion })
                                .FirstOrDefaultAsync();
                            
                            if(info != null)
                            {
                                sItem.Value.CurrentMoney = info.ShopMoney ?? 0; //Refreshing money from db.
                                updated = await _db.CharacterProperties.Where(x => x.CharacterId == sItem.Key &&
                                x.Key == CharacterConstant.KEY_MONEY && x.RowVersion == info.RowVersion)
                                    .UpdateAsync(x => new CharacterProperty() { ValueDecimal = sItem.Value.NewMoney });
                            }
                            if (updated == 0)
                            {
                                //Could not update, concurrency error after another try. Will try again on next cronjob.
                                break;
                            }
                        }
                    }
                    if(updated != 0)
                    {
                        foreach (var iItem in itemData)
                        {
                            updated = await _db.Items
                                .Where(x => x.Id == iItem.Key && x.RowVersion == iItem.Value.Version)
                                .UpdateAsync(x => new Item { Quantity = iItem.Value.NewQty });
                            if (updated == 0)
                            {
                                //concurrency check
                                var info = await _db.Items.Where(x => x.Id == iItem.Key)
                                    .Select(x => new { x.Quantity, x.RowVersion })
                                    .FirstOrDefaultAsync();
                                if (info != null)
                                {
                                    iItem.Value.CurrentQty = info.Quantity; //refreshing qty from database
                                    updated = await _db.Items
                                        .Where(x => x.Id == iItem.Key && x.RowVersion == info.RowVersion)
                                        .UpdateAsync(x => new Item { Quantity = iItem.Value.NewQty });
                                }
                                if (updated == 0)
                                {
                                    //Could not update, concurrency error after second try. Will try again on next cronjob.
                                    await transaction.RollbackAsync();
                                    break;
                                }
                            }
                        }
                    }
                    if(updated != 0)
                    {
                        await transaction.CommitAsync();
                        updates++;
                    }
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            return updates;
        }
