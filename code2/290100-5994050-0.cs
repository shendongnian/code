    public interface IQueryResult
    {
        int Foo { get; }
    }
    internal class QueryResult : IQueryResult
    {
        public Foo { get; set; }
    }
