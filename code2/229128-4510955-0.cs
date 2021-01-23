        var newList =
            new CheckBoxItemsList(MyCheckboxItemsList.Where(item=>item.Changed));
        // ...
        public class CheckboxItemsList<T> : List<T>
        {
            public CheckboxItemsList(IEnumerable<T> items)
            {
                // build list
            }
        }
