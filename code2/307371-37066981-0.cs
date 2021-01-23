    Table table = frame.AddTable();
    int columnsCount = 7;
    Enumerable.Repeat<Func<Column>>(table.AddColumn, columnsCount)
              .ToList()
              .ForEach(addColumn => addColumn());
    //or
    Enumerable.Range(0, columnsCount)
              .ToList()
              .ForEach(iteration => table.AddColumn());
