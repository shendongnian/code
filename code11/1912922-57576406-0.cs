    public static class LINQExtension
    {
        public static double CustomWhere(this IEnumerable<YourDataType> source)
        {
            if (source.Count() == 0)
                // your logic validation here
            source.Where(x =>
                         x.CompanyId == 1 &&
                         x.EmployerId == 1 &&
                         x.EmployeeId == 1 &&);
        }
    }
