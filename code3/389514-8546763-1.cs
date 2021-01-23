    public Counter<T> GetCounter<T>(string columnName)
    {
        if (columnName == "id")
            return new Counter<T>(this._table.IDs);
        else if (columnName == "name")
            return new Counter<T>(this._table.Names);
    }
