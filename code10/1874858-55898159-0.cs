    public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
    {
        if (items === null) return Enumerable.Empty<T>();
        return items.Select(item => new SelectListItem {
            Text = item.GetPropertyValue("Ime"),
            Value = item.GetPropertyValue("Id"),
            Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
        });
    }
