        public static void insertOrUpdateCustomer(Customer customer)
        {
            using (var db = getDb())
            {
                db.Entry(customer).State = !db.Customer.Any(f => f.CustomerId == customer.CustomerId) ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }
