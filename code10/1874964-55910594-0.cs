    public static class DataTableJoinExt {
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
                default:
                    throw new ArgumentException("MemberInfo must be of type FieldInfo or PropertyInfo", nameof(member));
            }
        }
        public static T GetValue<T>(this MemberInfo member, object srcObject) => (T)member.GetValue(srcObject);
    
        // ***
        // *** IEnumerable Extensions
        // ***
    
        public static IEnumerable<T> AsSingleton<T>(this T first) {
            yield return first;
        }
    
        // ***
        // *** DataTable Extensions
        // ***
        public static IEnumerable<DataColumn> DataColumns(this DataTable aTable) => aTable.Columns.Cast<DataColumn>();
        public static IEnumerable<string> ColumnNames(this DataTable aTable) => aTable.DataColumns().Select(dc => dc.ColumnName);
    
        // Create new DataTable from LINQ join results on DataTable
        // Expect T to be anonymous object of form new { [DataRow or other] d1, [DataRow or other] d2, ... }
        public static DataTable FlattenToDataTable<T>(this IEnumerable<T> src) {
            var res = new DataTable();
            if (src.Any()) {
                var firstRow = src.First();
                var memberInfos = typeof(T).GetPropertiesOrFields();
                var allDC = memberInfos.SelectMany(mi => (mi.GetMemberType() == typeof(DataRow)) ? mi.GetValue<DataRow>(firstRow).Table.DataColumns() : new DataColumn(mi.Name, mi.GetMemberType()).AsSingleton());
    
                foreach (var dc in allDC) {
                    var newColumnName = dc.ColumnName;
                    if (res.ColumnNames().Contains(newColumnName)) {
                        var suffixNumber = 1;
                        while (res.ColumnNames().Contains($"{newColumnName}.{suffixNumber}"))
                            ++suffixNumber;
                        newColumnName = $"{newColumnName}.{suffixNumber}";
                    }
                    res.Columns.Add(new DataColumn(newColumnName, dc.DataType));
                }
    
                foreach (var objRows in src)
                    res.Rows.Add(memberInfos.SelectMany(mi => (mi.GetMemberType() == typeof(DataRow)) ? mi.GetValue<DataRow>(objRows).ItemArray : mi.GetValue(objRows).AsSingleton()).ToArray());
            }
            return res;
        }
    }
