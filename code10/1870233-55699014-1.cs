    interface IQueryBuilder
    {
        IQuerable<T> BuildQuery<T>(...);
    }
    
    class EntityFrameworkQueryBuilder : IQueryBuilder
    {
        public IQuerable<T> BuildQuery<T>(...) => query;
    }
    
    class PostConditionQueryBuilderDecorator : IQueryBuilder
    {
        ctor(IQueryBuilder builder) => _builder = builder;
    
        public IQuerable<T> BuildQuery<T>(...) => query.Where(x => x.Foo != bar);
    }
