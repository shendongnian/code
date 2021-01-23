        public static FMVHistory CloneFMV(FMVHistory F) {
            FMVHistory F_Clone = new FMVHistory();
            Type typeToClone = F.GetType();
            Type[] BadGenericTypes = new Type[] { typeof(EntityCollection<>), typeof(EntityReference<>) };
            Type[] BadTypes = new Type[] { typeof(System.Data.EntityKey) };
            foreach (PropertyInfo pi in typeToClone.GetProperties().Where(p => p.CanWrite)) {
                if (pi.PropertyType.IsGenericType && BadGenericTypes.Contains(pi.PropertyType.GetGenericTypeDefinition())
                    || (BadTypes.Contains(pi.PropertyType))
                    || (pi.Name.Equals("nameOfYourPrimaryKeyWhichYouDontWantCloned"), StringComparison.CurrentCultureIgnoreCase)))
                    continue;
                pi.SetValue(F_Clone, pi.GetValue(F, null), null);
            }
            return F_Clone;
        }
