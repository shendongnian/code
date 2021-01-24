    public IEnumerable<IViewModel> MapRowsToModels<T>(Type viewType, IEnumerable<T> rows)
    {
        return rows.Select(row =>
        {
            var a = MapRowToModel(viewType, row);
            return a;
        });
    }
    public abstract IViewModel MapRowToModel(Type viewType, dynamic row);
