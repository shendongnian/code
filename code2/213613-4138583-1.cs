    var customerCriteria = session
        .CreateCriteria(typeof(Customer));
    customerCriteria.Add( Restrictions.Like("Name", "John", MatchMode.Exact) );
    customerCriteria.CreateCriteria("Adresses")
        .Add( Restriction.Eq("City", "NY") );
       
    var result = customerCriteria.ToList<Customer>();
