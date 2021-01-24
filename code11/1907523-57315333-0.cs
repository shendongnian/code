            foreach (var item in content)
            {
                model.Add(new CustomersModel { CustomerId = item.id,
                                               CustomerName = item.cname,
                                               PricingGroup = item.pg,
                                               PrGrId = item.pgid.ToString() });
            }
