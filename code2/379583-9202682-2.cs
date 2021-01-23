     var baseEF = typeof (BaseEFEntity);
            var baseLink = typeof (BaseLinkTable);
            var types =
                AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(
                    baseEF.IsAssignableFrom).Union(AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(
                        s => s.GetTypes()).Where(
                            baseLink.IsAssignableFrom));
            var sqlScript = crediLogicContext.ObjectContext.CreateDatabaseScript();
            foreach (var type in types)
            {
                var table = (TableAttribute) type.GetCustomAttributes(typeof (TableAttribute), true).FirstOrDefault();
                var tableName = (table != null ? table.Name : null) ?? Pluralizer.Pluralize(type.Name);
