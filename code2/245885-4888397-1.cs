            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Save(new Foo { Data = 1 });
                tx.Commit();
            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.CreateSQLQuery("select {foo.*} from {foo}")
                       .AddEntity("foo", typeof(Foo))
                       .SetCacheable(true)
                       .List();
                tx.Commit();
            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.CreateSQLQuery("select {foo.*} from {foo}")
                       .AddEntity("foo", typeof(Foo))
                       .SetCacheable(true)
                       .List();
                tx.Commit();
            }
