    for (int i = DS.Tables.Count - 1; i >= 0; i--)
    {
      var table = DS.Tables[i];
      for (int constraint = table.Constraints.Count - 1; constraint >= 0; constraint--)
        if (table.Constraints.CanRemove(table.Constraints[constraint]))
          table.Constraints.Remove(table.Constraints[constraint]);
    }
