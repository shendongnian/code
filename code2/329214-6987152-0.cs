    List<CustomerViewModel> result = Session.QueryOver<Customer>(() => customerAlias)
        .SelectList(list => list
            .Select(n => customerAlias.Name).WithAlias(() => model.Name)
            // I'm not sure if customerAlias works here or why you have declared it at all
            .Select(Projections.Cast(NHibernateUtil.String, Projections.Property<Customer>(c => c.DateCreated))).WithAlias(() => model.DateCreated))
        .TransformUsing(Transformers.AliasToBean<CustomerViewModel>());
        .Future<CustomerViewModel>()
        .ToList();
