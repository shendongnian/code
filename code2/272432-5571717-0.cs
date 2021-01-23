    /// <summary>
    /// A class that represents an employee. Notice that with each property
    /// (e.g. Id) there is a boolean property that has a similar name (e.g. IsIdSelected)
    /// this boolean property will be bound to the relevant DataGridCell.IsSelected
    /// property to indicate whther the cell representing this property were selected
    /// or not. In other words if you want to now the selected properties at any moment
    /// you just need to iterate throught the employees collection, and examine each
    /// boolean property for each property :D
    /// </summary>
    public class Employee
    {
        public int? Id { get; set; }
        public bool IsIdSelected { get; set; }
        public string Name { get; set; }
        public bool IsNameSelected { get; set; }
        public string Address { get; set; }
        public bool IsAddressSelected { get; set; }
    }
