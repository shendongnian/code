        var newList = MyCheckboxItemsList.Where(item=>item.Changed)
                                         .ToCheckboxItemsList();
        // ...
        public static class EnumerableExtensions
        {
            public static CheckboxItemsList<T> ToCheckboxItemsList(
                this IEnumerable<T> source)
            {
                var list = new CheckboxItemsList<T>();
                foreach (T item in source)
                {
                    list.Add(item);
                }
                return list;
            }
        }
