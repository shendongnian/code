    public static T CastByExample<T>(object o, T example) {
        return (T)o;
    }
    public static object MyMethod(object obj) {
        var example = new { FirstProperty = "abcd", SecondProperty = 100 };
        var casted = CastByExample(obj, example);
        return new {
            FirstProperty = casted.FirstProperty,
            SecondProperty = casted.SecondProperty,
            AddedProperty = true
        };
    }
