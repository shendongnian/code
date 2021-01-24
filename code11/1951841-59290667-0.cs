           var totalCompanies = db.Order_Details.GroupBy(x => x.Order.Customer.CompanyName).OrderByDescending(x=>x.Sum(y=> (float)y.Quantity * (float)y.UnitPrice * 1 - (y.Discount))).Take(5).ToList();
            List<string> bestCompanies = new List<string>();
            foreach (var item in totalCompanies)
            {
                bestCompanies.Add(item.Key);
            };
