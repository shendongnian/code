    public void Iterate<T>(IEnumerable<T> data)
    {
         foreach(T item in data) {...}
    }
    ...
    dynamic evil = myDataGrid;
    Iterate(evil);
