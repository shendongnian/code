    internal interface IEntityContext<TEntity>
    {
     ???
    }
    
    internal interface IMyInterfaceName<TEntity, TBusinessObject>
    {
    TBusinessObject MethodA(TEntity entity);
    Void MethodB(IEntityContext<TEntity> context, TBusinessObject obj, TEntity entity);
    }
