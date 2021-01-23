    public IQueryable<Contact> SearchCustomers(string query)
    {
        var ws = from w in query.Split()
                    where !String.IsNullOrWhiteSpace(w)
                    select new { Unpacked = w , Packed = PhoneNumber.Pack(w) };
    
        var q = Customers;
        foreach(var x in ws)
        {
            string ux = x.Unpacked;
            string px = x.Packed;
            q = q.Where(
                   c=> 
                    c.FirstName == ux
                    || c.LastName == ux
                    || c.EmailAddress == ux
                    || c.HomePhone == px
                    || c.CellPhone == px
                );
        }
        return q;
    }
