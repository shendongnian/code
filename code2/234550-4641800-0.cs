    public static class IEnumerableStringExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItemList(this IEnumerable<string> items)
        {
            return IEnumerableStringExtensions.ToSelectListItemList(items, string.Empty);
        }
        public static IEnumerable<SelectListItem> ToSelectListItemList(this IEnumerable<string> items, string selectedValue)
        {
            List<SelectListItem> listitems = new List<SelectListItem>(items.Count());
            foreach (string s in items)
            {
                listitems.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s,
                    Selected = selectedValue == s
                });
            }
            return listitems;
        }
    }
