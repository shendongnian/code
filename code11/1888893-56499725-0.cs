    public static IEnumerableExt {
        public static List<MemberInfo> GetPropertiesOrFields(this Type t, BindingFlags bf = BindingFlags.Public | BindingFlags.Instance) =>
            t.GetMembers(bf).Where(mi => mi.MemberType == MemberTypes.Field || mi.MemberType == MemberTypes.Property).ToList();
    
        public static DataTable ToDataTable<T>(this IEnumerable<T> rows) {
            var dt = new DataTable();
            if (rows.Any()) {
                var memberInfos = typeof(T).GetPropertiesOrFields();
                foreach (var info in memberInfos)
                    dt.Columns.Add(new DataColumn(info.Name, info.GetMemberType()));
    
                foreach (var r in rows)
                    dt.Rows.Add(memberInfos.Select(i => i.GetValue(r)).ToArray());
            }
            return dt;
        }
    }
