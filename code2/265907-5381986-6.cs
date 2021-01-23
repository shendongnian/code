        public static T CloneEntity<T>(T Obj) where T : EntityObject, new() {
            T Clone = new T();
            Type typeToClone = Obj.GetType();
            Type[] BadGenericTypes = new Type[] { typeof(EntityCollection<>), typeof(EntityReference<>) };
            Type[] BadTypes = new Type[] { typeof(System.Data.EntityKey) };
            foreach (PropertyInfo pi in typeToClone.GetProperties().Where(p => p.CanWrite)) {
                if (pi.PropertyType.IsGenericType && BadGenericTypes.Contains(pi.PropertyType.GetGenericTypeDefinition())
                    || (BadTypes.Contains(pi.PropertyType))
                    || (pi.Name.Equals(Extension.GetPropertyName(() => new FMVHistory().FMVHistoryId), StringComparison.CurrentCultureIgnoreCase)))
                    continue;
                pi.SetValue(Clone, pi.GetValue(Obj, null), null);
            }
            return Clone;
        }
