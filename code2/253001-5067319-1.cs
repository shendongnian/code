    public IEnumerable<string> YourFunction(...)
    {
        try
        {
            return _yourFunction(...);
        }
        catch (Exception e)
        {
            throw ExceptionMapper.Map(e, file.FullName);
        }
    }
    private IEnumerable<string> _yourFunction(...)
    {
        // Your code here
    }
