            var productTypes = new int[] {1,2,3,4};
            var query = from p in db.products
                        select p;
            if (productTypes.Contains(1))
                query.Add("productType1 = @0");
            if (productTypes.Contains(2))
                query.Add("productType2 = @0");
            if (productTypes.Contains(3))
                query.Add("productType3 = @0");
            if (productTypes.Contains(4))
                query.Add("productType4 = @0");
            if (productTypes.Count > 0)
            {
                string result = String.Join(" OR ", productTypes);
                query = query.Where("(" + result + ")", true);
            }
            var result = from p in query
                         select new {Id = p.ProductId, Name = p.ProductName };
