            optionsBuilder.UseFirebird(connectionString)
                .ReplaceService<IQueryCompilationContextFactory, MyFbSqlQueryCompilationContextFactory>();
    public class MyFbSqlQueryCompilationContext : RelationalQueryCompilationContext
    {
        public MyFbSqlQueryCompilationContext(
            QueryCompilationContextDependencies dependencies,
            ILinqOperatorProvider linqOperatorProvider,
            IQueryMethodProvider queryMethodProvider,
            bool trackQueryResults)
            : base(
                dependencies,
                linqOperatorProvider,
                queryMethodProvider,
                trackQueryResults)
        {
        }
        public override int MaxTableAliasLength => 31;
    }
    public class MyFbSqlQueryCompilationContextFactory : RelationalQueryCompilationContextFactory
    {
        public MyFbSqlQueryCompilationContextFactory(
            QueryCompilationContextDependencies dependencies,
            RelationalQueryCompilationContextDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }
        public override QueryCompilationContext Create(bool async)
            => async
                ? new MyFbSqlQueryCompilationContext(
                    Dependencies,
                    new AsyncLinqOperatorProvider(),
                    new AsyncQueryMethodProvider(),
                    TrackQueryResults)
                : new MyFbSqlQueryCompilationContext(
                    Dependencies,
                    new LinqOperatorProvider(),
                    new QueryMethodProvider(),
                    TrackQueryResults);
    }
