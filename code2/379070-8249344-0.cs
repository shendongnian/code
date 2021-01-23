    List<Customer> list = new List<Customer>();
    using(SqlDataReader rdr = GetReaderFromSomewhere()) {
      while(rdr.Read()) {
         Customer cust = new Customer();
         cust.Id = (int)rdr["Id"];
         list.Add(cust)
      }
    }
