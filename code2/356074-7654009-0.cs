    public static viod GetData(IHasDimensions thing)
    {
        var webClient = new WebClient();
        var wrapper = new WrapperClass(thing);
        if (thing.Distance.HasValue)
        {
            structure = new Structure((decimal)thing.Length.Value, (decimal)thing.Height.Value);
        }
        ...
    }
