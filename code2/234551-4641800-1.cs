    public static class IEnumerableStringExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItemList(this IEnumerable<string> items)
        {
            return IEnumerableStringExtensions.ToSelectListItemList(items, new List<string>());
        }
        public static IEnumerable<SelectListItem> ToSelectListItemList(this IEnumerable<string> items, string selectedValue)
        {
            return IEnumerableStringExtensions.ToSelectListItemList(items, new List<string>());
        }
        public static IEnumerable<SelectListItem> ToSelectListItemList(this IEnumerable<string> items, IEnumerable<string> selectedValues)
        {
            List<SelectListItem> listitems = new List<SelectListItem>(items.Count());
            foreach (string s in items)
            {
                listitems.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s,
                    Selected = selectedValues.Contains(s)
                });
            }
            return listitems;
        }
    }
