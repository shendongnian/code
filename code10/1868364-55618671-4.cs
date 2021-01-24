        static Expression Select<T>(this IQueryable<T> source, string[] fields)
        {
            var itemType = typeof(T);
            var groupType = itemType; //itemType.Derive();
            var itemParam = Expression.Parameter(itemType, "x");
            List<MemberAssignment> bindings = new List<MemberAssignment>();
            foreach (var property in fields)
            {
                Expression propertyExp;
                if (property.Contains("."))
                {
                    string[] childProperties = property.Split('.');
                    var binding = RecursiveSelectBindings(itemParam, itemType, itemParam, childProperties, 0);
                    bindings.Add(binding);
                }
                else
                {
                    var fieldValue = groupType.GetProperty(property, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    var fieldValueOriginal = Expression.Property(itemParam, fieldValue ?? throw new InvalidOperationException());
                    var memberAssignment = Expression.Bind(fieldValue, fieldValueOriginal);
                    bindings.Add(memberAssignment);
                }
            }
            var selector = Expression.MemberInit(Expression.New(groupType), bindings.ToArray());
            return Expression.Lambda(selector, itemParam);
        }
