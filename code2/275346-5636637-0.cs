    var competencySubQuery = DetachedCriteria.For<Employee>("employee2");
    competencySubQuery.CreateAlias("employee2.Competencies", "employee2Competencies");
    competencySubQuery.SetProjection(Projections.Count(Projections.Property("employee2Competencies.Competency")));
    competencySubQuery.Add(Restrictions.In("employee2Competencies.Competency",     searchCriteria.Competencies));
    competencySubQuery.Add(Restrictions.EqProperty("employee2.Id", "Employee.Id"));
    criteriaJunction.Add(Subqueries.Eq(searchCriteria.Competencies.Count(), competencySubQuery));
