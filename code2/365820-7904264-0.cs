    foreach(var rule in in m_testDictionary.Values)
    {
      var rowRules = rule as RowRules;
      if (rowRules != null) {
        // It's a RowRules
        continue;
      }
      var columnRules = rule as ColumnRules;
      if (columnRules != null) {
        // It's a ColumnRules
        continue;
      }
    }
