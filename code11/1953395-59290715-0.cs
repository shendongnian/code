    public void Main() {
        var baseTaskList = new List<Task<Base>>();
        var derivedTaskList = new List<Task<Derived>>();
    
        for ( var i = 1; i < 10; i++) {
            switch (i%2) {
                case 0:
                    derivedTaskList.Add(GetDerivedAsync());
                    break;
                default:
                    baseTaskList.Add(GetBaseAsync());
                    break;
            }
        }
    
        Task.WhenAll(baseTaskList);
        Task.WhenAll(derivedTaskList);
    }
