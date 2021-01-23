    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace EntryAssemblyAttributeDemo
    {
        /// <summary>
        /// For certain types of apps, such as web apps, <see cref="Assembly.GetEntryAssembly"/> 
        /// returns null.  With the <see cref="EntryAssemblyAttribute"/>, we can designate 
        /// an assembly as the entry assembly by creating an instance of this attribute, 
        /// typically in the AssemblyInfo.cs file.
        /// <example>
        /// [assembly: EntryAssembly]
        /// </example>
        /// </summary>
        [AttributeUsage(AttributeTargets.Assembly)]
        public sealed class EntryAssemblyAttribute : Attribute
        {
            /// <summary>
            /// Lazily find the entry assembly.
            /// </summary>
            private static readonly Lazy<Assembly> EntryAssemblyLazy = new Lazy<Assembly>(GetEntryAssemblyLazily);
    
            /// <summary>
            /// Gets the entry assembly.
            /// </summary>
            /// <returns>The entry assembly.</returns>
            public static Assembly GetEntryAssembly()
            {
                return EntryAssemblyLazy.Value;
            }
    
            /// <summary>
            /// Invoked lazily to find the entry assembly.  We want to cache this value as it may 
            /// be expensive to find.
            /// </summary>
            /// <returns>The entry assembly.</returns>
            private static Assembly GetEntryAssemblyLazily()
            {
                return Assembly.GetEntryAssembly() ?? FindEntryAssemblyInCurrentAppDomain();
            }
    
            /// <summary>
            /// Finds the entry assembly in the current app domain.
            /// </summary>
            /// <returns>The entry assembly.</returns>
            private static Assembly FindEntryAssemblyInCurrentAppDomain()
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var entryAssemblies = new List<Assembly>();
                foreach (var assembly in assemblies)
                {
                    // Note the usage of LINQ SingleOrDefault.  The EntryAssemblyAttribute's AttrinuteUsage 
                    // only allows it to occur once per assembly; declaring it more than once results in 
                    // a compiler error.
                    var attribute =
                        assembly.GetCustomAttributes().OfType<EntryAssemblyAttribute>().SingleOrDefault();
                    if (attribute != null)
                    {
                        entryAssemblies.Add(assembly);
                    }
                }
    
                // Note that we use LINQ SingleOrDefault to ensure we found one and only one assembly with the 
                // EntryAssemblyAttribute.  The EntryAssemblyAttribute should only be put on one assembly 
                // per application.
                return entryAssemblies.SingleOrDefault();
            }
        }
    }
