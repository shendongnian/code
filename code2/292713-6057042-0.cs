        public void TestMultiMapWithSplit()
        {
            var sql = @"select 1 as Id, 'abc' as Name, 2 as Id, 'def' as Name";
            var product = connection.Query<Product, Category, Product>(sql,
               (prod, cat) =>
               {
                   prod.Category = cat;
                   return prod;
               }).First();
            // assertions
            product.Id.IsEqualTo(1);
            product.Name.IsEqualTo("abc");
            product.Category.Id.IsEqualTo(2);
            product.Category.Name.IsEqualTo("def");
        }
