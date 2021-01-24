    public static class AssemblyUtils
    {
        /// <summary>
        ///     Get Application folder path
        /// </summary>
        /// <returns></returns>
        public static string GetExeFilePath()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        }
        /// <summary>
        /// Get all types of object that implement the type <typeparamref name="T"/> inside the assembly
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="filename">File path of the assembly</param>
        /// <returns>An enumerable of type <see cref="Type"/> that implements <typeparamref name="T"/></returns>
        public static IEnumerable<Type> GetTypesFromAssembly<T>(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"DLL file not found. File path: {filename}");
            var asm = Assembly.LoadFrom(filename);
            var types = asm.GetTypes();
            var typeFilter = new TypeFilter(InterfaceFilter);
            foreach (var type in types)
            {
                var interfaces = type.FindInterfaces(typeFilter, typeof(T).ToString());
                if (interfaces.Length > 0)
                    // We found the type that implements the interface
                    yield return type;
            }
        }
        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> instance that implements interface of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type of object to find and return</typeparam>
        /// <param name="filename">Name of the assembly file</param>
        /// <returns>Instance of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> GetInterfacesFromAssembly<T>(string filename, params object[] args)
        {
            var types = GetTypesFromAssembly<T>(filename);
            foreach (var type in types)
            {
                yield return (T)Activator.CreateInstance(type, args);
            }
        }
        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> instance that implements interface of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type of object to find and return</typeparam>
        /// <param name="directory">Path of directory containing assemblies</param>
        /// <returns>Instance of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> GetInterfacesFromAssemblyDirectory<T>(string directory, params object[] args)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"Directory could not be found. Path: { directory }");
            }
            return Directory.GetFiles(directory, "*.dll").SelectMany(filename => GetInterfacesFromAssembly<T>(filename, args));
        }
        /// <summary>
        /// Type filter for filtering the interface in a class
        /// </summary>
        /// <param name="typeObj">Object type</param>
        /// <param name="criteriaObj">Filter criteria</param>
        /// <returns>Whether the criteria is meet or not</returns>
        private static bool InterfaceFilter(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
