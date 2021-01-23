        var dCriteria1 = DetachedCriteria.For<InvoiceRow>("r")
                .SetProjection(Projections.Property("r.RowNumber"))
                .SetProjection(Projections.Property("r.InvoiceID")) // Must be last!!!!
                .Add(Restrictions.Eq("r.RowNumber", 1));
        var dCriteria2 = DetachedCriteria.For<InvoiceRow>("r")
                .SetProjection(Projections.Property("r.RowNumber"))
                .SetProjection(Projections.Property("r.InvoiceID")) // Must be last!!!!
                .Add(Restrictions.Eq("r.RowNumber", 2));
 
        var invoices = Session.CreateCriteria<Invoice>()
                .Add(Subqueries.PropertyIn("ID", dCriteria1))
                .Add(Subqueries.PropertyIn("ID", dCriteria2))          
                .List<Invoice>();
