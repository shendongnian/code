    ...
        if (condition)
            DoWork(() => Code1, () => Code2);
        else
        {
            DoWork(() => Code2, () => Code1);
        }
    ...
    
    private void Code1()
    {
        // Code 1
    }
    private void Code2()
    {
        // code 2
    }
   
    private void DoWork(Action action1, Action action2)
    {
        action1();
        action2();
    }
