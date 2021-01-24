    public List<Test> GetTests()
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("pqual_db")))
        {
            connection.Open();
            var output = connection.Query<Test, Product, Tester, Test>("pqual_db.sptests_GetTests", (tests, products, tester) => 
        { 
          tests.Product = products; 
          tests.Tester = tester; 
          return tests; 
        }, splitOn:"tester_id,product_id ").ToList();
         return output;
        }
    }
