    IReadOnlyDictionaru<SomeEnum, Action<T1,T2,T3,T3,T5,T6,T7>> _actions 
    {
        get => new Dictionary<SomeEnum, Action<T1,T2,T3,T3,T5,T6,T7>> 
            {
               {SomeEnum.Do, OptionIsDo},
               {SomeEnum.NoDo, OptionIsNoDo}
            } 
    }
    
    public void DoSomething(SomeEnum option)
    {
        _action[option](1,"a", null, DateTime.Now(), 0.5m, null, 'a'); // _action[option].Invoke(1,"a", null, DateTime.Now(), 0.5m, null, 'a');
    }
    
    
    pub void OptionIsDo(int a, string b, object c, DateTime d, decimal e, object f, char c)
    {
       return ;
    }
    
    pub void OptionIsNoDo(int a, string b, object c, DateTime d, decimal e, object f, char c)
    {
       return ;
    }
