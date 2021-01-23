    protected void DoSomething(){
        Transport newOne =  GetType()
                               .GetConstructors()[0]
                               .Invoke(new[] {"some name"})
    }
