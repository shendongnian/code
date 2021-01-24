        public static dynamic GetClassFromString(string className)
        {
            var classAddress = $"NetCoreScripts.{className}";
            Type type = GetType(classAddress);
            // Check whether the class is existed?
            if (type == null)
                return null;
            // Then create an instance
            object instance = Activator.CreateInstance(type);
            return instance;
        }
