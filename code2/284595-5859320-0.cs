    Order fromDb;
    using (ISession session = SessionFactory.OpenSession())
    {
        fromDb = session.Get<Order>(_order.Id);
        NHibernateUtil.Initialize(fromDb.Customer);
    }
