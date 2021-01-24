    public Capteurs Current
    {
        get => List[Index];
        set => List[Index] = value;
    }
    public CurrencyManager CurrencyManager 
    { 
        get => BindingContext[capteursBindingSource] as CurrencyManager; 
    }
    public IList<Capteurs> List 
    { 
        get => capteursBindingSource.DataSource as IList<Capteurs>; 
    }
    public int Index
    {
        get => BindingContext[capteursBindingSource].Position;
        set => BindingContext[capteursBindingSource].Position = value;
    }
