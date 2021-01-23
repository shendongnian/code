    using System.Reflection;
    using HWClassLibrary.Debug;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    namespace HWClassLibrary.Helper
    {
        public static class TypeNameExtender
        {
            private static IEnumerable<Type> _referencedTypesCache;
            public static void OnModuleLoaded() { _referencedTypesCache = null; }
            public static string PrettyName(this Type type)
            {
                if(type == typeof(int))
                    return "int";
                if(type == typeof(string))
                    return "string";
                var result = PrettyTypeName(type);
                if(type.IsGenericType)
                    result = result + PrettyNameForGeneric(type.GetGenericArguments());
                return result;
            }
            private static string PrettyTypeName(Type type)
            {
                var result = type.Name;
                if(type.IsGenericType)
                    result = result.Remove(result.IndexOf('`'));
                if (type.IsNested && !type.IsGenericParameter)
                    return type.DeclaringType.PrettyName() + "." + result;
                if(type.Namespace == null)
                    return result;
                var conflictingTypes = ReferencedTypes
                    .Where(definedType => definedType.Name == type.Name && definedType.Namespace != type.Namespace)
                    .ToArray();
                var namespaceParts = type.Namespace.Split('.').Reverse().ToArray();
                var namespacePart = "";
                for(var i = 0; i < namespaceParts.Length && conflictingTypes.Length > 0; i++)
                {
                    namespacePart = namespaceParts[i] + "." + namespacePart;
                    conflictingTypes = conflictingTypes
                        .Where(conflictingType => (conflictingType.Namespace + ".").EndsWith(namespacePart))
                        .ToArray();
                }
                return namespacePart + result;
            }
            private static IEnumerable<Type> ReferencedTypes
            {
                get
                {
                    if(_referencedTypesCache == null)
                        _referencedTypesCache = Assembly.GetEntryAssembly().GetReferencedTypes();
                    return _referencedTypesCache;
                }
            }
            private static string PrettyNameForGeneric(Type[] types)
            {
                var result = "";
                var delim = "<";
                foreach(var t in types)
                {
                    result += delim;
                    delim = ",";
                    result += t.PrettyName();
                }
                return result + ">";
            }
        }
    }
