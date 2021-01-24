    Type type;
    if (ModelClassTypesDictionary.TryGetValue(modelClassName, out type))
    {
    return type;
    }
    lock (_ModelClassTypelock)
    {
    if (ModelClassTypesDictionary.TryGetValue(modelClassName, out type))
           {
           	return type;
    }
           type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == modelClassName && x.FullName.Contains("Model.Models"));
                    ModelClassTypesDictionary.Add(modelClassName, type);
    }
