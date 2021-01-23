    class FieldSorter : IComparer, IComparer<DisplayAttribute>, IEqualityComparer<DisplayAttribute>
    {
        public int Compare(object x, object y)
        {
            return Compare((DisplayAttribute)x, (DisplayAttribute)y);
        }
        public int Compare(DisplayAttribute x, DisplayAttribute y)
        {
            return x.Order.CompareTo(y.Order);
        }
        public bool Equals(DisplayAttribute x, DisplayAttribute y)
        {
            return Compare(x, y) == 0;
        }
        public int GetHashCode(DisplayAttribute obj)
        {
            return obj.GetHashCode();
        }
        public static SortedList<DisplayAttribute, PropertyInfo> GetSortedFields(Type type)
        {
            PropertyInfo[] props = type.GetProperties();
            var sortedProps = new SortedList<DisplayAttribute, PropertyInfo>(props.Length, new FieldSorter());
            object[] atts;
            int assignedOrder = 1000; // anything without pre-assigned order gets a ridiculously high order value. same for duplicates.
            foreach (var prop in props)
            {
                atts = prop.GetCustomAttributes(typeof(DisplayAttribute), true);
                if (atts.Length > 0)
                {
                    var att = (DisplayAttribute)atts[0];
                    if (!att.GetOrder().HasValue || sortedProps.Keys.Contains(att, new FieldSorter()))
                        att.Order = assignedOrder++;
                    sortedProps.Add(att, prop);
                }
            }
            return sortedProps;
        }
    }
