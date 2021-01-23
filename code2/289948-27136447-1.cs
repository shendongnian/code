    public IEnumerable<Customer> Getall()
            {
                List<Customer> lcustomer= new List<Customer>();
                //Get Customer data from Database or wherever
                lcustomer.Add(new Customer{ firstname= "Quentin ", lastname= "tarantino" });
                return lcustomer;
            }
