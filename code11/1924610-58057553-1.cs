      DataTable table = new DataTable();
      table.Columns.Add("a", typeof(string));
      table.Columns.Add("b", typeof(string));
      table.Columns.Add("C", typeof(string));
      table.Columns.Add("d", typeof(string));
      table.Columns.Add("e", typeof(string));
      table.Columns.Add("F", typeof(string));
      var A = new List<string> { "a", "b", "c" };
      // HashSet is a better collection in the context:
      //  1. We can specify comparer (e.g. we can ignore case)
      //  2. It's faster if the collection has many items
      // Sure, you can put A.Contains instead of columnsToKeep.Contains
      HashSet<string> columnsToKeep = 
        new HashSet<string>(A, StringComparer.OrdinalIgnoreCase);
      // For i-th column we should either either keep column (do nothing) or remove it
      for (int i = table.Columns.Count - 1; i >= 0; --i)
        if (!columnsToKeep.Contains(table.Columns[i].ColumnName))
          table.Columns.RemoveAt(i);
