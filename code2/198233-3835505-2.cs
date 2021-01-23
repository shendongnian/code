    protected T readColumnValue<T>(Column<T> column)
    {
      switch (column.FormatType)
      {
        case FormatType.Int:
          return (T)readInt();
      }
    }
