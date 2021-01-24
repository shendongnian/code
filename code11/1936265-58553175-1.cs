    public interface IUnitOfWork
    {
        Foo Foo { get; set; }
    }
    private BaseResult<TUnitOfWork> GetUnitOfWorkByCompiledModel<TUnitOfWork>(DbCompiledModel compiledModel) where TUnitOfWork : IUnitOfWork, new()
    {
        return new BaseResult<TUnitOfWork>
        {
            Payload = new TUnitOfWork()
                      {
                          Foo = myFoo
                      };
        };
    }
