        public class Customer
    {
        string Name { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
    }
    public class Title
    {
        string Name { get; set; }
        decimal Cost { get; set; }
    }
    public class Rental
    {
        Customer Renter { get; }
        Title Media { get; }
        DateTime Due {get;}
        public void Rent(Customer, Title);
    }
