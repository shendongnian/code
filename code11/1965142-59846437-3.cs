    private static ConcurrentDictionary<string, Lazy<Type>> ModelClassTypesDictionary;
    public override Type GetModelClassType(string modelClassName)
    {
        if (ModelClassTypesDictionary == null)
            ModelClassTypesDictionary = new ConcurrentDictionary<string, Lazy<Type>>(GetConcurrencyLevel(), GetModelClassTypeInitialCapacity());
        return ModelClassTypesDictionary.GetOrAdd(modelClassName, y => new Lazy<Type>(
                () =>
                {
                    return System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == modelClassName && x.FullName.Contains("Model.Models"));
                })).Value;
    }
