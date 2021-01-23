    object ConvertToAny(string input, Type target)
    {
        // handle common types
        if (target == typeof(int))
            return int.Parse(input);
        if (target == typeof(double)
            return double.Parse(input);
        ...
        // handle enums
        if (target.BaseType == typeof(Enum))
            return Enum.Parse(target, input);
        // handle anything with a static Parse(string) function
        var parse = target.GetMethod("Parse",
                        System.Reflection.BindingFlags.Static |
                        System.Reflection.BindingFlags.Public,
                        null, new []{typeof(string)}, null);
        if (parse != null)
            return parse.Invoke(null, new object[] { input });
    }
