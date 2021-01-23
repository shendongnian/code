    public Result(string ElementName, ResultProvider Provider, Func<U, T> converter)
    {
        this.ElementName = ElementName;
        try
        {
           this.Value = converter(Provider());
        }
        catch (Exception e) {
           this.Exception = e;
        }
     }
