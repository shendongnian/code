 c#
internal interface ITable
{
    string Name {get;}
    IQueryable Source {get;}
    IQueryable Destination {get;}
    Type Type {get;}
}
and use `List<ITable>` ?
Where `Table<T>` becomes:
 c#
internal class Table<TEntity> : ITable where TEntity : class
{
    internal string Name {get; set;}
    internal DbSet<TEntity> Source {get; set;}
    internal DbSet<TEntity> Destination {get; set;}
    string ITable.Name => Name;
    IQueryable ITable.Source => Source;
    IQueryable ITable.Destination => Destination;
    Type ITable.Type => typeof(T);
    internal Table(string name, DbSet<TEntity> source, DbSet<TEntity> destination)
    {
        Name = name;
        Source = source;
        Destination = destination;
    }
}
