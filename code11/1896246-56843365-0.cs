    public static class DataTableExt {
        // convert a class containing members that are composite into a flattened DataTable
        // only flatten one level deep; do not flatten collections
        public static DataTable FlattenToDataTable<T>(this IEnumerable<T> src) {
            var oldMITs = typeof(T).GetMITs();
            var ans = new DataTable(nameof(T));
    
            foreach (var mit in oldMITs)
                if (mit.IsSimpleOrEnumerable)
                    ans.Columns.Add(new DataColumn(mit.mi.Name, mit.mt));
    
            foreach (var mit in oldMITs)
                if (!mit.IsSimpleOrEnumerable)
                    foreach (var subMI in mit.subMIs) {
                        // find unique name
                        var possibleName = subMI.Name;
                        var namect = 1;
                        while (ans.Columns.Contains(possibleName)) {
                            possibleName = $"{subMI.Name}{namect}";
                            ++namect;
                        }
                        ans.Columns.Add(new DataColumn(possibleName, subMI.GetMemberType()));
                    }
    
            foreach (var srcObj in src) {
                var dr = ans.NewRow();
                srcObj.CopyFlattenedToDataRow(oldMITs, dr);
                ans.Rows.Add(dr);
            }
    
            return ans;
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
    
        static void CopyFlattenedToDataRow<T>(this T srcObject, List<MemberInfoType> oldMITs, DataRow ansRow) {
            var colIdx = 0;
    
            foreach (var mit in oldMITs)
                if (mit.IsSimpleOrEnumerable)
                    ansRow[colIdx++] = mit.mi.GetValue(srcObject);
    
            foreach (var mit in oldMITs)
                if (!mit.IsSimpleOrEnumerable) {
                    var subObj = mit.mi.GetValue(srcObject);
                    foreach (var subMI in mit.subMIs)
                        ansRow[colIdx++] = subMI.GetValue(subObj);
                }
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
    }
