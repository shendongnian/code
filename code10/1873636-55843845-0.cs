    public class Item
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public int employeeID { get; set; }
        public decimal salary { get; set; }
    }
    public class Filter
    {
        public String PropertyName { get; set; }
        public String PropertyValue { get; set; }
    }
    private string GetPropertyValue(Item item, string propertyName)
    {
        return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
    }
