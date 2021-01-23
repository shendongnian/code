    static class IEnumerableCheckboxItemsExtensions {
        public static ToCheckboxItemsList(
            this IEnumerable<CheckboxItems> checkboxItems
        ) {
            return new CheckboxItemsList(checkboxItems);
        }
    }
