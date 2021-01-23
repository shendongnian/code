    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> items, Func<T, string> value, Func<T, string> text, object selectedValue)
        {
            return items.Select(item => new SelectListItem
                                         {
                                             Text = text(item),
                                             Value = value(item),
                                             Selected = (selectedValue.ToString() == value(item))
                                         });
        }
