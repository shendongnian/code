     Session.CreateCriteria<Person>()
                    .SetProjection(
                    Projections.ProjectionList()
                        .Add(Projections.GroupProperty("FirstName")))
                        .Add(Projections.GroupProperty("LastName")))
                    .List<Person>().Count();
