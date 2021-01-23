    private void GhostTagUpdate(int id)
    {
        using (var session = OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                var tag = session.Get<Tag>(id);
                transaction.Commit();
            }
        }
    }
