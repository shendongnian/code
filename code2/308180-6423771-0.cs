    // or maybe interface IColumn instead, depending on your needs
    class Column
    {
        // any non-generic stuff common to all columns
    }
    class Column<T> : Column where T : IComparable, IConvertible
    {
        // any generic stuff specific to Column<T>
    }
    class Table
    {
        private List<Column> _columns;
    }
