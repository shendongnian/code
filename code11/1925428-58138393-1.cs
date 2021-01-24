    public YourUnknownType<T> AddBlock<TBlock>()
    {
        var type = typeof(TBlock);
        var attributes = attributes.GetCustomAttributes(typeof(string), inherit: true); // or false if you don't need inheritation
        var attribute = attributes.FirstOrDefault() as ActionNameAttribute;
        if (attribute.Name == this.Context.ActioName)
        {
            // place here the block init
        }
        return AnithingYouActuallyReturn();
    }
