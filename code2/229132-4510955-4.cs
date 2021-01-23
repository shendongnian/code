        var newList = MyCheckboxItemsList.Where(item=>item.Changed)
                                         .ToCheckboxItemsList();
        // ...
        public static class EnumerableExtensions
        {
            public static CheckboxItemsList ToCheckboxItemsList(
                this IEnumerable<CheckboxItems> source)
            {
                var list = new CheckboxItemsList();
                foreach (T item in source)
                {
                    list.Add(item);
                }
                return list;
            }
        }
