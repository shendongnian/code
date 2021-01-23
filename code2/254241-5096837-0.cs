    public string getAll(string d1, string d2, string d3)
    {
       using(CustomDataContext dc = new CustomDataContext())
       {
         IQueryable<Customer> query = dc.Customers;
         if (d1 != null)
         {
           query = query.Where(c => c.Name.StartsWith(d1));
         }
         if (d2 != null)
         {
           query = query.Where(c => c.Orders.Any(o => o.OrderNumber == d2));
         }
         if (d3 != null)
         {
           query = query.Where(c => c.FavoriteColor == d3);
         }
         query =
            from c in query
            order c by c.Name
            select c;
         List<Customer> results = query.Take(5).ToList();
         string answer = SomeMethod(results);
         return answer;
       }
    } 
