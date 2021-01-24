        public static IQueryable<TModel> GroupByExpression(List<string> propertyNames, IQueryable<TModel> sequence)
        {
           var grouping = sequence.GroupBy(propertyNames.ToArray());
            var selectParam = Expression.Parameter(grouping.ElementType, "item");
            Expression selectPropEx = selectParam;
            var selectBody = Expression.New(typeof(TModel).GetConstructors()[0]);
            var selectBindings = new List<MemberAssignment>();
            foreach (var property in propertyNames)
            {
                var keyProp = "Key." + property;
                //support nested, relation grouping
                string[] childProperties = keyProp.Split('.');
                var prop = grouping.ElementType.GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase);
                selectPropEx = Expression.MakeMemberAccess(selectParam, prop);
                var binding = PropertyGrouping.RecursiveSelectBindings(selectParam, prop.PropertyType, selectPropEx, childProperties, 1);
                selectBindings.Add(binding);
            }
            MemberInitExpression selectMemberInit = Expression.MemberInit(selectBody, selectBindings);
            var queryable = grouping
                .Select(Expression.Lambda<Func<IGrouping<TModel, TModel>, TModel>>(selectMemberInit, selectParam));
            return queryable;
        }
