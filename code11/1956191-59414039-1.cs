    public static readonly Dictionary<Type, IConstants> Constants =
        new Dictionary<Type, IConstants> {
            [typeof(Thing1)] = new Thing1(),
            [typeof(Thing2)] = new Thing2(),
        };
