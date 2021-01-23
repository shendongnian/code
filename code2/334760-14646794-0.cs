    if (CallSessionContext.HasBind(_sessionFactory))
                {
                    session = SessionFactory.GetCurrentSession();
                }
                else
                {
                    session = SessionFactory.OpenSession();
                    CallSessionContext.Bind(session);
                }
