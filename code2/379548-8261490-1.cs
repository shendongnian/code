    List<object>[] addedLists = New.Keys.Except(Existing.Keys)
                                        .Select(key => New[key])
                                        .ToArray();
    object[] addedObjects = Existing.Keys.Intersect(New.Keys)
                                         .SelectMany(key => New[key].Except(Existing[key])
                                         .ToArray();
