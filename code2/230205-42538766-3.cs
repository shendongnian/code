        public static IEnumerable<MemberInfo> GetAllFieldsAndPropertiesOfClassOrdered<T>()
        {
            return
                from mi in GetAllFieldsAndPropertiesOfClass<T>()
                let orderAttr = (ColumnOrderAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnOrderAttribute))
                orderby orderAttr == null ? int.MaxValue : orderAttr.Order, mi.Name
                select mi;
        }
