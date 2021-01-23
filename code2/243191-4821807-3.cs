    internal interface IEntityContext<TEntity>
    {
     ???
    }
    
    internal interface MyInterfaceName<TEntity, TBusinessObject>
    {
    TBusinessObject MethodA(TEntity entity);
    Void MethodB(IEntityContext<TEntity> context, TBusinessObject obj, TEntity entity);
    }
