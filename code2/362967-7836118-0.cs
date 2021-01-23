    public List<Foo> getFoos()
    {
        return typeof(MyClass).GetFields(BindingFlags.Static | BindingFlags.Public)
                              .Where(x => x.FieldType == typeof(Foo))
                              .Select(x => x.GetValue(null))
                              .Cast<Foo>()
                              .ToList();
    }
