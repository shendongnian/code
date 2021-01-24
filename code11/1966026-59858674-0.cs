     var product = uniqProductList.OrderBy(a => a.Price)
              .GroupBy(a => a.Price).FirstOrDefault()
              .Aggregate(new List<Product>(), (result, item) =>
              {
                result.Add(item);
                if (result.Count() > 1)
                    result = new List<Product>();
                return result;
            }).FirstOrDefault();
 
