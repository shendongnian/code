csharp
public class BaseServiceUnitTest<TEntity> where TEntity : BaseEntity
{
    private IBaseService<TEntity> _service;
    public BaseServiceUnitTest(Constructor ctor)
    {
        _service = Create(/* your mocked dependencies here */);
    }
    protected abstract IBaseServce<TEntity> Create(Dependency1 d1, Dependency2 d2);
    //...implemented methods from IBaseServiceUnitTest
}
public class CustomEntityServiceUnitTest : BaseServiceUnitTest<CustomEntity>
{
    // "arg1, arg2"
    protected override IBaseService<CustomEntity> Create(Dependency1 d1, Dependency2 d2) =>
        new BaseService<CustomerEntity>(d1, d2);
}
