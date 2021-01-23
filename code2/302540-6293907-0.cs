    for (int i = 0; i < knownIds; i += 1000)
    {
      var page = knownIds.Skip(i).Take(1000).ToArray();
      loadedEntities.AddRange(
        Repository.GetAll()
          .Where(x => page.Contains(x.ID)));
    }
