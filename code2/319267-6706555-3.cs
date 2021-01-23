    // Define your interface to match the properties which are common to both types
    interface IPerson
    {
        string Name
        {
            get;
            set;
        }
    }
    // Then use partial declarations like this (must be in the same namespace as the generated classes)
    public partial class Person : IPerson { }
    public partial class Customer : IPerson { }
