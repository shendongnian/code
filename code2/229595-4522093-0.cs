        using (ISession session = sessionFactory.OpenSession())
        {
            foreach (var item in session.CreateCriteria<Model.Circuit>().List<Model.Circuit>())
            {
                item.Documents.Clear();
                session.Delete(item);
            }
            session.Flush();
            foreach (var item in session.CreateCriteria<Model.Issue>().List<Model.Issue>())
            {
                item.Documents.Clear();
                session.Delete(item);
            }
            session.Flush();
        }
