    //Your initial data list
    var productInformationItems = new List<ProductTermAndPricingDataItem>();
    var productPricingGetDataItems = productInformationItems.ToLookup(item => item.ProductID)
                                                            .Select(grouping => new ProductPricingGetDataItem
                                                            {
                                                                ProductID = grouping.Key,
                                                                Terms = grouping.Select(item => new Terms
                                                                {
                                                                    Price = item.PriceAmount,
                                                                    Term = item.BillingPeriodName
                                                                }).ToList()
                                                            }).ToList();
