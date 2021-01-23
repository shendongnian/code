    // only flush the session once. I have a using syntax to disable
    // autoflush within a limited scope (without direct access to the
    // session from the business logic)
    session.Flush();
    session.FlushMode = FlushMode.Never;
    for (int i = 0; i < knownIds; i += 1000)
    {
      var page = knownIds.Skip(i).Take(1000).ToArray();
      loadedEntities.AddRange(
        Repository.GetAll()
          .Where(x => page.Contains(x.ID)));
    }
    session.FlushMode = FlushMode.Auto;
