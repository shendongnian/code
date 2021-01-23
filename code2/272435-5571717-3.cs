    /// <summary>
    /// A class that represents an employee. Notice that with each property
    /// (e.g. Id) there is a Boolean property that has a similar name (e.g. IsIdSelected)
    /// this Boolean property will be bound to the relevant DataGridCell.IsSelected
    /// property to indicate whether the cell representing this property were selected
    /// or not. In other words if you want to know the selected properties at any moment
    /// you just need to iterate through the employees collection, and examine each
    /// Boolean property for each property :D
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
