    public static RequestModel<T> ToRequestModel<T>(this T model)
    {
        return new RequestModel<T>()
        {
            Id = Guid.NewGuid(),
            Model = model
            // assign other property value
        };
    }
