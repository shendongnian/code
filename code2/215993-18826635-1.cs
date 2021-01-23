        private static void Test()
        {
            IList<Guid> list = CreateList<Guid>();
            Guid objTemp = Guid.NewGuid();
            list.Add(objTemp);
        }
        private static List<TItem> CreateList<TItem>()
        {
            Type listType = GetGenericListType<TItem>();
            List<TItem> list = (List<TItem>)Activator.CreateInstance(listType);
            return list;
        }
        private static Type GetGenericListType<TItem>()
        {
            Type objTyp = typeof(TItem);
            var defaultListType = typeof(List<>);
            Type[] itemTypes = { objTyp };
            Type listType = defaultListType.MakeGenericType(itemTypes);
            return listType;
        }
