    ISession session = GetSession();
    var criteria = session.CreateCriteria(typeof(Product));
    var ids= new[] {1,2,3};
    criteria.Add(new InExpression("Id", ids));
    var products = criteria.List<Product>();
