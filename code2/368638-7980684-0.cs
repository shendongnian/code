    var clientQuery = DetachedCriteria.For<Client>("Client");
    clientQuery = clientQuery.CreateAlias("Person", "p");
                    
    var primaryQuery = DetachedCriteria.For<Client>("Primary");
    primaryQuery.SetProjection(Projections.Property("Primary.Id"));
    primaryQuery.Add(Restrictions.EqProperty("Client.PrimaryClient", "Primary.Id"));
    primaryQuery.CreateAlias("Person", "p");
    primaryQuery.Add(Restrictions.Like("p.Surname", lastName, MatchMode.Start));
    
    var secondaryQuery = DetachedCriteria.For<Client>();
    secondaryQuery.SetProjection(Projections.Property("Id"));
    secondaryQuery.CreateCriteria("SecondaryClients")
                  .CreateCriteria("Person")
                  .Add(Restrictions.Like("Surname", lastName, MatchMode.Start));
    
    clientQuery.Add(Restrictions.Disjunction()
                        .Add(Restrictions.Like("p.Surname", lastName, MatchMode.Start))
                        .Add(Subqueries.Exists(primaryQuery))
                        .Add(Subqueries.PropertyIn("Id", secondaryQuery)));
