    private readonly Func<DateTime> _nowProvider;
    public SomeClass(Func<DateTime> nowProvider)
    {
        _nowProvider = nowProvider;
    }
    public bool Foo()
    {
        return (_nowProvider().DayOfWeek == DayOfWeek.Sunday);
    }
