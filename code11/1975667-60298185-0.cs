    public ValidationContext(object instance, IServiceProvider serviceProvider,
                             IDictionary<object, object> items) 
    {
        if (instance == null) {
           throw new ArgumentNullException("instance");
        }
        ....
