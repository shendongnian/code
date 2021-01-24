    private int _userId;
    public CrewRepository(DataContext dataContext) : base(dataContext)
    {
        _userId  = (int)UserCode.System;
    }
