    HibernateDelegate<IList<IAssetLiabilityModel>> del = delegate(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(ICompany));
            criteria.CreateCriteria("Company.Addresses", "Addresses");
            criteria.Add(Restrictions.Like("Addresses",<your_search_string>)); 
            criteria.SetResultTransformer(CriteriaSpecification.DistinctRootEntity);
            HibernateTemplate.PrepareCriteria(criteria);
            return criteria.List<ICompany>();
        };
        IList<ICompany> companies = HibernateTemplate.Execute(del);
