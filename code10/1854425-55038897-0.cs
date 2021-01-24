    public object Create(Type type)
    {
        try
        {
            return Activator.CreateInstance(type);
        }
        catch (MissingMethodException e)
        {
            Console.WriteLine($"Gotcha! Type: {type}");
            // or whatever handling, eg. rethrow with type included:
            throw new MyException(type, e);
        }
    }
