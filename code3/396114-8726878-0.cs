    var dCriteria1 = DetachedCriteria.For<InvoiceRow>("r")
            .Add(Restrictions.EqProperty("r.InvoiceID", "i.ID"))
            .Add(Restrictions.Eq("r.RowNumber", 1));
    var dCriteria2 = DetachedCriteria.For<InvoiceRow>("r")
            .Add(Restrictions.EqProperty("r.InvoiceID", "i.ID"))
            .Add(Restrictions.Eq("r.RowNumber", 2));
    
    var invoices = Session.CreateCriteria<Invoice>("i")
       .Add(Subqueries.Exists(dCriteria1))
       .Add(Subqueries.Exists(dCriteria2))
       .List<Invoice>();
