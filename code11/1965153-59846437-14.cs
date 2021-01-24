    private static ConcurrentDictionary<string, Type> ModelClassTypesDictionary;
            public Type GetModelClassType(string modelClassName)
            {
                if (ModelClassTypesDictionary == null)
                    ModelClassTypesDictionary = new ConcurrentDictionary<string, Type>(GetConcurrencyLevel(), GetModelClassTypeInitialCapacity());
                Type type = null;
                ModelClassTypesDictionary.GetOrAdd(modelClassName, y =>
                       {
                           type= System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == modelClassName && x.FullName.Contains("Model.Models"));
                           return type;
                       });
                return type;
            }
