    public class AccountSearch
    {
        public decimal Amount { get; set; }
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
    
        public IQueryable<Account> BuildQuery (IQueryable<Account> source)
        {
            var query = source.Where (a =>
                a.Amount == Amount);
    
            // you can use more twisted logic here, like applying where clauses conditionally
            if (!string.IsNullOrEmpty (Address))
                query = query.Where (a =>
                   a.Address == Address);
    
            // ...
    
            return query;     
        }
    }
