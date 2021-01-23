    session.QueryOver<WorkIncident>(() => t1Alias)
                    .Where(w => w.ModifierNtId == "test")
                    .And(w => w.ModifiedDate < DateTime.Now && w.ModifiedDate > DateTime.Now)
                    .And(w => w.Status == TicketStatus.Open)
                    .And(Restrictions.Disjunction()
                        .Add(Restrictions.Where<WorkIncident>(w => w.TicketNumber == 1))
                        .Add(Subqueries.WhereProperty(() => t1Alias.TicketNumber).In(
                            QueryOver.Of<WorkIncident>(() => t2Alias)
                                    .Where(() => t2Alias.Status != t1Alias.Status)
                                    .And(() => t2Alias.TicketNumber == t1Alias.TicketNumber)
                                    .And(Restrictions.EqProperty(
                                        Projections.Property<WorkIncident>(w=> w.Version), 
                                        Projections.SqlFunction(
                                            new VarArgsSQLFunction("(","-",")"),
                                            NHibernateUtil.Int32,
                                            Projections.Property(()=> t1Alias.Version),
                                            Projections.Constant(1)
                                        )))
                                    .Select(w => w.TicketNumber)))
                    ).List();
