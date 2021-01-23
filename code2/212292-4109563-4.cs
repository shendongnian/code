    public static class MvcExtensions
    {
        public static SelectList ToSelectList<T>(this IEnumerable<T> list) where T : IDropdownList
        {
            IEnumerable<T> result;
            if (list == null)
            {
                result = (IEnumerable<T>) new List<EmptyDropdownList>{new EmptyDropdownList()};
            }
            else
            {
                result = list;
            }
            string value = Reflector.GetPropertyName<T>(x => x.Id);
            string text = Reflector.GetPropertyName<T>(x => x.Text);
            return new SelectList(result, value, text);
        }
    }
