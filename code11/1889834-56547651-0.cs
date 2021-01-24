    public static class AnonymousExt {
        // convert a class containing members that are composite into a flattened class object
        // only flatten one level deep; do not flatten collections
        public static object FlattenToNewObject<T>(this T srcObject) {
            var oldMITs = typeof(T).GetMITs();
            var newType = oldMITs.FlattenedType();
            var newMIs = newType.GetPropertiesOrFields();
    
            return srcObject.CopyFlattened(oldMITs, newType, newMIs);
        }
    
        public static IEnumerable<object> FlattenToNewObjects<T>(this IEnumerable<T> src) {
            var oldMITs = typeof(T).GetMITs();
            var newType = oldMITs.FlattenedType();
            var newMIs = newType.GetPropertiesOrFields();
    
            foreach (var srcObj in src)
                yield return srcObj.CopyFlattened(oldMITs, newType, newMIs);
        }
    
        class MemberInfoType {
            public MemberInfo mi;
            public Type mt;
            public bool IsSimpleOrEnumerable;
            public List<MemberInfo> subMIs;
        }
    
        static List<MemberInfoType> GetMITs(this Type t) =>
            t.GetPropertiesOrFields().Select(mi => new { mi = mi, mt = mi.GetMemberType() })
            .Select(mit => new { mit, IsSimpleOrEnumerable = mit.mt.IsSimple() || mit.mt.IsIEnumerable() })
            .Select(mitb => new MemberInfoType { mi = mitb.mit.mi, mt = mitb.mit.mt, IsSimpleOrEnumerable = mitb.IsSimpleOrEnumerable, subMIs = mitb.IsSimpleOrEnumerable ? null : mitb.mit.mt.GetPropertiesOrFields() })
            .ToList();
    
        static Type FlattenedType(this List<MemberInfoType> oldMITs) {
            var newTypeDict = new Dictionary<string, Type>();
            // add all simple/collection members
            foreach (var mit in oldMITs)
                if (mit.IsSimpleOrEnumerable)
                    newTypeDict.Add(mit.mi.Name, mit.mt);
    
            // flatten remaining composite members
            foreach (var mit in oldMITs)
                if (!mit.IsSimpleOrEnumerable) {
                    foreach (var subMI in mit.subMIs) {
                        // find unique name
                        var possibleName = subMI.Name;
                        var namect = 1;
                        while (newTypeDict.ContainsKey(possibleName)) {
                            possibleName = $"{subMI.Name}{namect}";
                            ++namect;
                        }
                        newTypeDict.Add(possibleName, subMI.GetMemberType());
                    }
                }
    
            return FindOrMakeSimpleAnonType(newTypeDict);
        }
    
        static object CopyFlattened<T>(this T srcObject, List<MemberInfoType> oldMITs, Type newType, List<MemberInfo> newMIs) {
            var ansObj = Activator.CreateInstance(newType);
            var memberIdx = 0;
            foreach (var mit in oldMITs)
                if (mit.IsSimpleOrEnumerable)
                    newMIs[memberIdx++].SetValue(ansObj, mit.mi.GetValue(srcObject));
            foreach (var mit in oldMITs)
                if (!mit.IsSimpleOrEnumerable) {
                    var subObj = mit.mi.GetValue(srcObject);
                    foreach (var subMI in mit.subMIs)
                        newMIs[memberIdx++].SetValue(ansObj, subMI.GetValue(subObj));
                }
            return ansObj;
        }
    
        // ***
        // *** Type Extensions
        // ***
        public static List<MemberInfo> GetPropertiesOrFields(this Type t, BindingFlags bf = BindingFlags.Public | BindingFlags.Instance) =>
            t.GetMembers(bf).Where(mi => mi.MemberType == MemberTypes.Field || mi.MemberType == MemberTypes.Property).ToList();
    
        // ***
        // *** MemberInfo Extensions
        // ***
        public static Type GetMemberType(this MemberInfo member) {
            switch (member) {
                case FieldInfo mfi:
                    return mfi.FieldType;
                case PropertyInfo mpi:
                    return mpi.PropertyType;
                case EventInfo mei:
                    return mei.EventHandlerType;
                default:
                    throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", nameof(member));
            }
        }
    
        public static object GetValue(this MemberInfo member, object srcObject) {
            switch (member) {
                case FieldInfo mfi:
                    return mfi.GetValue(srcObject);
                case PropertyInfo mpi:
                    return mpi.GetValue(srcObject);
                case MethodInfo mi:
                    return mi.Invoke(srcObject, null);
                default:
                    throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo or MethodInfo", nameof(member));
            }
        }
        public static T GetValue<T>(this MemberInfo member, object srcObject) => (T)member.GetValue(srcObject);
    
        public static void SetValue(this MemberInfo member, object destObject, object value) {
            switch (member) {
                case FieldInfo mfi:
                    mfi.SetValue(destObject, value);
                    break;
                case PropertyInfo mpi:
                    mpi.SetValue(destObject, value);
                    break;
                case MethodInfo mi:
                    mi.Invoke(destObject, new object[] { value });
                    break;
                default:
                    throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo or MethodInfo", nameof(member));
            }
        }
        public static void SetValue<T>(this MemberInfo member, object destObject, T value) => member.SetValue(destObject, (object)value);
    
        // ***
        // *** Type Extensions
        // ***
        public static bool IsNullableType(this Type aType) =>
        // instantiated generic type only                
            aType.IsGenericType &&
            !aType.IsGenericTypeDefinition &&
            Object.ReferenceEquals(aType.GetGenericTypeDefinition(), typeof(Nullable<>));
    
        // Stack Overflow
        public static bool IsSimple(this Type type) =>
            type.IsNullableType() ? type.GetGenericArguments()[0].IsSimple()
                                  : type.IsPrimitive ||
                                    type.IsEnum ||
                                    type.Equals(typeof(string)) ||
                                    type.Equals(typeof(decimal)) ||
                                    type.Equals(typeof(TimeSpan)) ||
                                    type.Equals(typeof(DateTime));
        public static bool IsIEnumerable(this Type type) => typeof(IEnumerable).IsAssignableFrom(type);
    
        // ***
        // *** Anonymous Type Extensions
        // ***
        private static readonly CustomAttributeBuilder CompilerGeneratedAttributeBuilder = new CustomAttributeBuilder(typeof(CompilerGeneratedAttribute).GetConstructor(Type.EmptyTypes), new object[0]);
        private static ModuleBuilder AnonTypeMB;
        private static int AssemCount = 25;
    
        // create a pseudo anonymous type (POCO) from an IDictionary of property names and types
        // using public fields instead of properties
        // no methods are defined on the type
        public static Type MakeSimpleAnonType(IDictionary<string, Type> objDict) {
            // find or create AssemblyBuilder for dynamic assembly
            if (AnonTypeMB == null) {
                var assemblyName = new AssemblyName($"MyDynamicAssembly{AssemCount}");
                var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                AnonTypeMB = ab.DefineDynamicModule("MyDynamicModule");
            }
            // get a dynamic TypeBuilder
            var typeBuilder = AnonTypeMB.DefineType($"<>f__AnonymousType{AssemCount++}`{objDict.Keys.Count}", TypeAttributes.AnsiClass | TypeAttributes.Class | TypeAttributes.AutoLayout | TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
            typeBuilder.SetCustomAttribute(CompilerGeneratedAttributeBuilder);
    
            // create generic parameters for every field
            string gtpName(string fieldName) => $"<{fieldName}>j__TPar";
            var gtpnames = objDict.Keys.Select(k => gtpName(k)).ToArray();
            var gtpbs = typeBuilder.DefineGenericParameters(gtpnames);
            var gtpN2Bs = gtpnames.Zip(gtpbs, (n, pb) => new { n, pb }).ToDictionary(g => g.n, g => g.pb);
    
            // add public fields to match the source object
            var fbs = new List<FieldBuilder>();
            foreach (var srcFieldName in objDict.Keys)
                fbs.Add(typeBuilder.DefineField(srcFieldName, gtpN2Bs[gtpName(srcFieldName)], FieldAttributes.Public));
    
            // Fix the generic class
            var fieldTypes = objDict.Values.ToArray();
            return typeBuilder.CreateType().MakeGenericType(fieldTypes);
        }
    
        static string MakeAnonymousTypeKey(IDictionary<string, Type> objDict) => objDict.Select(d => $"{d.Key}~{d.Value}").Join("|");
    
        public static Dictionary<string, Type> PrevAnonTypes = new Dictionary<string, Type>();
        public static Type FindOrMakeSimpleAnonType(IDictionary<string, Type> objDict) {
            var wantedKey = MakeAnonymousTypeKey(objDict);
            if (!PrevAnonTypes.TryGetValue(wantedKey, out var newType)) {
                newType = MakeSimpleAnonType(objDict);
                PrevAnonTypes[wantedKey] = newType;
            }
    
            return newType;
        }
    
        // ***
        // *** IEnumerable Extensions
        // ***
        public static string Join(this IEnumerable<string> strings, string sep) => String.Join(sep, strings);
    }
