    [AttributeUsage(AttributeTarget.Property)]
    class IncludeInComparisonAttribute : Attribute { }
    class Order
    {
        List<AllItem> Items { get; set; }
        [IncludeInComparison]
        string Name { get; set; }
        long Amount { get; set; }
        [IncludeInComparison]
        int Code { get; set; }
        override bool Equals(Order other)
        {
            Type orderType = typeof(Order);
            foreach (PropertyInfo property in orderType.GetProperties()
            {
                if (property.CustomAttributes.Includes(typeof(IncludeInComparisonAttribute))
                {
                    object value1 = property.GetValue(this);
                    object value2 = propetty.GetValue(other);
                    if (value1.Equals(value2) == false)
                        return false;
                }
            }
            return true;
        }
    }
