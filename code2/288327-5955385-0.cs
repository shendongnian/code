    public static IList<SelectListItem> ToSelectItemList<T>(
        this IEnumerable<T> list, 
        Func<T, string> textSelector, 
        Func<T, string> valueSelector, T selected) where T : class
    {
        var results = new List<SelectListItem>();
        if (list != null)
        {
            results.AddRange(
                list.Select(item => new SelectListItem
                {
                    Text = textSelector.Invoke(item), 
                    Value = valueSelector.Invoke(item), 
                    Selected = selected != null ? selected.Equals(item) : false
                }));
        }
         return results;
    }
