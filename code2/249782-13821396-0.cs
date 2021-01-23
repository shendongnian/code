    var orderIDsContainingCurrentSku = DetachedCriteria.For<OrderItem>()
        .Add<OrderItem>(x=>x.Product.SKU==sku)
        .SetProjection(Projections.Property("Order.id"));
    var skusOfProductsAppearingInOrdersContainingCurrentSku = DetachedCriteria.For<OrderItem>()
        .SetProjection(Projections.GroupProperty("Product.id"))
        .AddOrder(NHibernate.Criterion.Order.Desc(Projections.Count("Order.id")))
        .Add<OrderItem>(x=>x.Product.SKU!=sku)
        .Add(Subqueries.PropertyIn("Order.id", orderIDsContainingCurrentSku))
        .SetMaxResults(15);
    var recommended = _session.CreateCriteria<Product>()
        .SetFetchMode<Product>(x => x.Descriptors, FetchMode.Join)
        .Add(Subqueries.PropertyIn("id", skusOfProductsAppearingInOrdersContainingCurrentSku))
        .SetResultTransformer(Transformers.DistinctRootEntity)
        .List<Product>();
