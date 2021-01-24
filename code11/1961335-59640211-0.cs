    using (var context = new DBEntities())
    {
       var result = (from c in context.Client.Include("Address")
                where c.IsActive
                select c).ToList();
    }
