        var newList =
            new CheckboxItemsList(MyCheckboxItemsList.Where(item=>item.Changed));
        // ...
        public class CheckboxItemsList : List<CheckboxItems>
        {
            public CheckboxItemsList(IEnumerable<CheckboxItems> collection)
                : base(collection)
            {
            }
        }
