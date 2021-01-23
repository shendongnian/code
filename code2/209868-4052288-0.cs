    private List<MyClass> mEnumerable;
    public IEnumerable<MyClass> GenerateEnumerable()
    {
        mEnumerable = mEnumerable ?? CreateEnumerable()
        return mEnumerable;
    }
    private List<MyClass> CreateEnumerable()
    {
        //Code to generate List Here
    }
