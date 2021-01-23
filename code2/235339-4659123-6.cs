        public static List<SelectListItem> GenerateKeyValuePair<T>(Func<T, string> nameGetter, T itemToNoInclude) 
            where T : struct, IComparable, IConvertible
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var enumList = Enum.GetValues(typeof(T));
            foreach (var curr in enumList)
            {
                T t = (T)curr;
                if (t.Equals(itemToNoInclude) == false)
                {
                    list.Add(new SelectListItem() { Text = nameGetter(t), Value = Convert.ToInt32(t).ToString() });
                }
            }
            return list;
        }
