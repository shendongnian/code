    #if CONDITION_1
    using MyAbstractBusinessEntity = LogEntity;
    #else
    using MyAbstractBusinessEntity = AbstractBusinessEntity;
    #endif
    // ...
    protected override void BeforeAdd(MyAbstractBusinessEntity entity)
    {
        // in CONDITION_1, the case is a no-op
        ((LogEntity)entity).DateTimeInsert = DateTime.Now;
        base.BeforeAdd(entity);
    }
 
