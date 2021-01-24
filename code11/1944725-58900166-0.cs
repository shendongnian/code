var Upadate(Customer customer) {
    // Authorization code here maybe
    using( var context = ... ) {
       var dbCustomer = c.Customers.FirstOrDefault( c => c.Id = customer.id );
       if( dbCustomer == null ) throw new KeyNotFoundException("Customer not found!");
       dbCustomer.A = ...;
       dbCustomer.B = ...;
    
       context.SaveChanges();
}
*I would encourage you to use names starting with a lowercase letter for variables.*
