               var a = allocationsGrouped
                    .Where(product => !string.IsNullOrEmpty(product.PRODUCT_NAME))
                    .GroupBy(product => product.PRODUCT_NAME)
                    .Select(group => new
                    {
                        Item = group.First(), 
                        EmvSum = group.Sum(x => x.EMV)
                    });
    
                foreach (var ac in a)
                {
                    var item2 = new FirmWideAllocationsViewModel();
                    item2.Hierarchy = new List<string>();
                    item2.Hierarchy.Add(manStratName);
                    item2.Hierarchy.Add(ac.Item.PRODUCT_NAME);
                    item2.FirmID = ac.Item.FIRM_ID;
                    item2.FirmName = ac.Item.FIRM_NAME;
                    item2.ManagerStrategyID = ac.Item.MANAGER_STRATEGY_ID;
                    item2.ManagerStrategyName = ac.Item.MANAGER_STRATEGY_NAME;
                    item2.ManagerAccountClassID = ac.Item.MANAGER_ACCOUNTING_CLASS_ID;
                    item2.ManagerAccountingClassName = ac.Item.MANAGER_ACCOUNTING_CLASS_NAME;
                    item2.ManagerFundID = ac.Item.MANAGER_FUND_ID;
                    item2.ManagerFundName = ac.Item.MANAGER_FUND_NAME;
                    item2.Nav = ac.Item.NAV;
                    item2.EvalDate = ac.Item.EVAL_DATE.HasValue ? ac.Item.EVAL_DATE.Value.ToString("MMM dd, yyyy") : string.Empty;
                    item2.ProductID = ac.Item.PRODUCT_ID;
                    item2.ProductName = ac.Item.PRODUCT_NAME;
                    item2.UsdEmv = Math.Round((decimal)ac.Item.UsdEmv);
                    item2.GroupPercent = ac.Item.GroupPercent;
                    item2.WeightWithEq = ac.Item.WEIGHT_WITH_EQ;
                    //assign aggregate Sum here
                    item2.EmvSum = ac.EmvSum;  
                    result.Add(item2);
                }            
