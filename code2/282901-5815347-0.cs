    private List<Employee> CreateSortList<T>(
                        IEnumerable<Employee> dataSource,
                        string fieldName, SortDirection sortDirection)
        {
            List<Employee> returnList = new List<Employee>();
            returnList.AddRange(dataSource);
            // get property from field name passed
            System.Reflection.PropertyInfo propInfo = typeof(T).GetProperty(fieldName);
            Comparison<Employee> compare = delegate(Employee a, Employee b)
            {
                bool asc = sortDirection == SortDirection.Ascending;
                object valueA = asc ? propInfo.GetValue(a, null) : propInfo.GetValue(b, null);
                object valueB = asc ? propInfo.GetValue(b, null) : propInfo.GetValue(a, null);
                //comparing the items
                return valueA is IComparable ? ((IComparable)valueA).CompareTo(valueB) : 0;
            };
            returnList.Sort(compare);
            return returnList;
        }
