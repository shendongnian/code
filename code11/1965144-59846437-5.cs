        private static ConcurrentDictionary<string, Type> ModelClassTypesDictionary;
        public Type GetModelClassType(string modelClassName)
        {
            if (ModelClassTypesDictionary == null)
                ModelClassTypesDictionary = new ConcurrentDictionary<string, Type>(GetConcurrencyLevel(), GetModelClassTypeInitialCapacity());
            Type type;
            if (ModelClassTypesDictionary.TryGetValue(modelClassName, out type))
            {
                return type;
            }
            type = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == modelClassName && x.FullName.Contains("Model.Models"));
            ModelClassTypesDictionary.TryAdd(modelClassName, type);
            return type;
        }
