    public interface IQuery
    {
        void Execute(Agency agency, Citation query);
    }
    public class OracleQuery : IQuery
    {
        // Implementation
    }
    public class PickQuery : IQuery
    {
        // Implementation
    }
